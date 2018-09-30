using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Help
{
  public class ArticleNomination
  {
    [Key]
    public int ID_ArticleNomination { get; set; }

    public User NominatedUser { get; set; } 

    public User RequestedUser { get; set; }

    public string ArticleTitle { get; set; }

    public string ArticleDescription { get; set; }

    public string Comment { get; set; }

    public ICollection<Topic> Topics { get; set; }

    public ICollection<Tag> Tags { get; set; }

    public DateTime NominationedDate { get; set; }

    public bool IsSeen { get; set; }

    public DateTime SeenDate { get; set; }
  }
}