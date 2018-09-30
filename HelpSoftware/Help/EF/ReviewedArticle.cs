using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  public class ReviewedArticle
  {
    [Key]
    public int ID_ReviewedArticle { get; set; }

    public User ReviewedUser { get; set; }

    public Article ArticleReviewed { get; set; }

    public DateTime ReviewTime { get; set; }

    public string Comment { get; set; }
  }
}