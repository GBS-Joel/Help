using Microsoft.ML.Runtime.Api;

namespace Help.AI
{
  public class ArticleLikeData
  {
    [Column("0")]
    public float Label;

    [Column(ordinal: "1")]
    public string ArticlePreview;

    [Column(ordinal: "2")]
    public string ArticleText;

    [Column(ordinal: "3")]
    public string ArticleTitle;

    [Column(ordinal: "4")]
    public string Tag1;

    [Column(ordinal: "5")]
    public string Tag2;

    [Column(ordinal: "6")]
    public string Topic1;

    [Column(ordinal: "7")]
    public string Topic2;

    [Column(ordinal: "8")]
    public string Created;
  }
}