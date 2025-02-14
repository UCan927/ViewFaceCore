﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ViewFaceCore.Model
{
    /// <summary>
    /// 识别使用的设备类型
    /// </summary>
    public enum DeviceType
    {
        /// <summary>
        /// 自动（默认）
        /// </summary>
        [Description("SEETA_DEVICE_AUTO")]
        AUTO = 0,

        /// <summary>
        /// CPU
        /// </summary>
        [Description("SEETA_DEVICE_AUTO")]
        CPU = 1,

        /// <summary>
        /// GPU（无效）
        /// </summary>
        [Description("SEETA_DEVICE_GPU")]
        GPU = 2,
    }
}
