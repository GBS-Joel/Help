using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Help
{
  public class Article
  {
    [Key]
    public int ID_Article { get; set; }

    public string ArticleText { get; set; }

    public string ArticlePreview { get; set; }

    public string ArticleTitle { get; set; }

    public List<Tag> Tags { get; set; }

    public List<Topic> Topics { get; set; }

    public virtual User Author { get; set; }

    public DateTime? Created { get; set; }

    public User LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public int? Views { get; set; }

    public int Stars { get; set; }

    public int Favorits { get; set; }

    public bool Public { get; set; }
  }
}