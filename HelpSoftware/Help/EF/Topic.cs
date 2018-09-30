using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  public class Topic
  {
    [Key]
    public int ID_Topic { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public Topic ParentTopic { get; set; }

    public List<Topic> ChildTopics { get; set; }

    public DateTime CreatedDate { get; set; }

    public User Author { get; set; }

    public User LastModifier { get; set; }

    public DateTime LastModified { get; set; }
  }
}