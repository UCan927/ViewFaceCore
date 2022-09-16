﻿using ViewFaceCore.Configs.Enums;
using ViewFaceCore.Extensions;

namespace ViewFaceCore.Models;

/// <summary>
/// 质量评估结果
/// </summary>
public sealed class QualityResult : IFormattable
{
    private float score = 0;
    private QualityLevel level = QualityLevel.Low;

    internal QualityResult(QualityLevel level, float score)
    {
        this.level = level;
        this.score = score;
    }

    /// <summary>
    /// 质量评估等级
    /// </summary>
    public QualityLevel Level => level;

    /// <summary>
    /// 质量评估分数
    /// <para>越大越好，没有范围限制</para>
    /// </summary>
    public float Score => score;

    #region IFormattable
    /// <summary>
    /// 返回可视化字符串
    /// </summary>
    /// <returns></returns>
    public override string ToString() => ToString(null, null);
    /// <summary>
    /// 返回可视化字符串
    /// </summary>
    /// <param name="format">D:返回状态的描述文本</param>
    /// <returns></returns>
    public string ToString(string format) => ToString(format, null);
    /// <summary>
    /// 返回可视化字符串
    /// </summary>
    /// <param name="format">D:返回状态的描述文本</param>
    /// <param name="formatProvider"></param>
    /// <returns></returns>
    public string ToString(string format, IFormatProvider formatProvider)
    {
        string ltips = nameof(Level), stips = nameof(Score);

        if ((formatProvider ?? Thread.CurrentThread.CurrentCulture) is CultureInfo cultureInfo && cultureInfo.Name.StartsWith("zh"))
        { ltips = "等级"; stips = "分数"; }

        if (format?[0] == 'D')
        { return $"{{{ltips}:{Level.ToDescription()}, {stips}:{Score}}}"; }
        else return $"{{{ltips}:{Level}, {stips}:{Score}}}";
    }
    #endregion
}
