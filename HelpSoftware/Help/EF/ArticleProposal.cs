using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  public class ArticleProposal
  {
    [Key]
    public int ID_ArticleProposal { get; set; }

    public string ArticleTitle { get; set; }

    public string ArticleDescription { get; set; }

    public string Comment { get; set; }

    public ICollection<Topic> Topics { get; set; }

    public ICollection<Tag> Tags { get; set; }

    public DateTime CreatedDate { get; set; }

    public User AssignedUser { get; set; }

    public string RequesterName { get; set; }

    public string RequesterEMail { get; set; }
  }
}