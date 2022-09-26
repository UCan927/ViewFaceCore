# SeetaFace6 Build

用于在各个平台编译[SeetaFace6](https://github.com/SeetaFace6Open/index "SeetaFace6")。以及收集并修复了官方仓库中的一些错误。

### 编译方法
#### Linux

Linux脚本来源：https://blog.ofortune.xyz/2020/08/30/seetaface6-intro/
1. 安装编译工具（Debian系）
```shell
sudo apt install git gcc g++ cmake -y
```
PS: 如果armhf无法安装g++，提示"libtirpc-dev : Depends: libtirpc3 (= 1.3.1-1) but 1.3.1-1+deb11u1 is to be installed"，下载"https://packages.debian.org/bullseye/armhf/libtirpc3/download"，使用dkpg -i重新安装。  

2. 下载ViewFaceCore源码  
```shell
git clone https://github.com/ViewFaceCore/ViewFaceCore.git
```

3. 下载SeetaFace6源码  
```shell
mkdir ViewFaceCore/src/SeetaFace && cd ViewFaceCore/src/SeetaFace
git clone --recursive https://github.com/ViewFaceCore/index.git
```

4. 授权编译脚本  
```shell
cd ../../scripts/SeetaFace6/
sudo chmod +x build.*.sh
```

5. 开始编译（x64平台）
```shell
sudo ./build.linux.x64.sh
```

#### Winodws

1. 安装VS 2019编译工具  
需要选择MSVC v142 VS2019工作负载，如图所示：
![](https://raw.githubusercontent.com/ViewFaceCore/ViewFaceCore/dev/docs/images/vs.png)

2. 下载ViewFaceCore源码  
```shell
git clone https://github.com/ViewFaceCore/ViewFaceCore.git
```

3. 下载SeetaFace6源码  
在ViewFaceCore下面的src文件中创建文件夹SeetaFace，并进入，然后clone SeetaFace6源码到SeetaFace中
```shell
git clone --recursive https://github.com/ViewFaceCore/index.git
```

4. 双击对应架构脚本开始编译  
在项目ViewFaceCore根目录下面的`scripts/SeetaFace6`文件中找到`build.win.vc.x64.bat`或`build.win.vc.x86.bat`。双击打开或CMD中打开，开始编译。

### 修复内容

#### 1. QualityOfLBN对象不管是动态创建还是new创建，传过去的ModelSetting参数都会出现异常，取不到model数组的值。
**来自：** https://github.com/seetafaceengine/SeetaFace6/issues/33  
**修复方式：**
把头文件`QualityOfLBN.h`的51行
```cpp
QualityOfLBN(const seeta::ModelSetting &setting = seeta::ModelSetting())
```
改为
```cpp
QualityOfLBN( const SeetaModelSetting &setting )
```

源文件`QualityOfLBN.cpp`的728行
```cpp
QualityOfLBN::QualityOfLBN(const seeta::ModelSetting &setting)
```
改为
```cpp
QualityOfLBN::QualityOfLBN( const SeetaModelSetting &setting )
```

#### 2. 活体检测错误  
**来自：** https://github.com/seetafaceengine/SeetaFace6/issues/22  
**修复方式：**  
修改`FaceAntiSpoofing.h`的38行  
```cpp
explicit FaceAntiSpoofing( const seeta::ModelSetting &setting );
```
改为  
```cpp
explicit FaceAntiSpoofing( const SeetaModelSetting &setting );
```

修改`FaceAntiSpoofing.cpp`的1235行  
```cpp
FaceAntiSpoofing::FaceAntiSpoofing( const seeta::ModelSetting &setting )
```
改为  
```cpp
FaceAntiSpoofing::FaceAntiSpoofing( const SeetaModelSetting &setting )
```

#### 3. 眼睛状态检测错误
**修复方式：**  
修改`EyeStateDetector.h`的16行  
```cpp
SEETA_API explicit EyeStateDetector(const seeta::ModelSetting &setting);
```
改为  
```cpp
SEETA_API explicit EyeStateDetector(const SeetaModelSetting &setting);
```

修改`EyeStateDetector.cpp`的653行  
```cpp
EyeStateDetector::EyeStateDetector(const seeta::ModelSetting &setting)
```
改为  
```cpp
EyeStateDetector::EyeStateDetector(const SeetaModelSetting &setting)
```

#### 4. 口罩识别错误  
**修复方式：**  

修改`MaskDetector.h`的17行  
```cpp
SEETA_API explicit MaskDetector(const seeta::ModelSetting &setting = seeta::ModelSetting() );
```
改为  
```cpp
SEETA_API explicit MaskDetector(const SeetaModelSetting &setting);
```

修改`MaskDetector.cpp`的427行  
```cpp
MaskDetector::MaskDetector(const seeta::ModelSetting &setting)
```
改为  
```cpp
MaskDetector::MaskDetector(const SeetaModelSetting &setting)
```

#### 5. win10,vs2019,vc14环境下编译OpenRoleZoo报错

**来自：** https://github.com/SeetaFace6Open/index/issues/4  
**修复方式：**  
修改代码`OpenRoleZoo/include/orz/mem/pot.h`，在第9行`#include<memory>`后面插入一行`#include <functional>`补充所需要的头文件。

#### 6. TenniS Windows下编译报错
报错：`'towlower': is not a member of 'std'`  
**修复方式：**  
修改代码`TenniS\src\compiler\argparse.cpp`，第21行
```cpp
std::transform(cvt.begin(), cvt.end(), cvt.begin(), std::towlower);
```
改为  
```cpp
std::transform(cvt.begin(), cvt.end(), cvt.begin(), std::tolower);
```
添加头文件引用
```cpp
#include <algorithm>
```
