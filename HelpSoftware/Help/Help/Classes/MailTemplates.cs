using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  public static class EMailTemplates
  {
    public static string AccountActivatedMessageTemplate = @"<h1 style=""color: #5e9ca0;"">Hey {0}</h1>
                  <h2 style = ""color: #2e6c80;""> Your Account has been Activated.</h2>
                  <p>You are now registrated and you can use the Product fully and without any... industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p>
                  <p>&nbsp;</p>
                  <p>Thank You and...</p>
                  <p><strong>the help Team</strong></p>
                  <hr />
                  <h2 style = ""color: #2e6c80;""> &nbsp;</h2>
                  <p>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</p>
                  <p><strong>&nbsp;</strong></p>
                  <p>&nbsp;</p>
                  <p><strong>&nbsp;</strong></p>";


    public static string UserLikedArticle = @"<h1 style = ""color: #5e9ca0;"" > Hey {0}</h1>
                  <h2 style = ""color: #2e6c80;"">{1} Has Liked Your Article {2}</h2>
                  <p>{3}</p>
                  <p>Thank You and...</p>
                  <p><strong>the help Team</strong></p>
                  <hr />
                  <h2 style = ""color: #2e6c80;"" > &nbsp;</h2>
                  <p>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</p>
                  <p><strong>&nbsp;</strong></p>
                  <p>&nbsp;</p>
                  <p><strong>&nbsp;</strong></p>";

    public static string UserFavoritedArticle = @"<h1 style = ""color: #5e9ca0;"" > Hey {0}</h1>
                  <h2 style = ""color: #2e6c80;"">{1} Has Favorited Your Article {2}</h2>
                  <p>{3}</p>
                  <p>Thank You and...</p>
                  <p><strong>the help Team</strong></p>
                  <hr/>
                  <h2 style = ""color: #2e6c80;""> &nbsp;</h2>
                  <p>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</p>
                  <p><strong>&nbsp;</strong></p>
                  <p>&nbsp;</p>
                  <p><strong>&nbsp;</strong></p>";


    public static string NominatedForArticle = @"<h1 style=""color: #5e9ca0;"">Hey {0}</h1>
                  <h2 style = ""color: #2e6c80;"" >{1} Has Nominated You To Write the Article {2}</h2>
                  <p>{3}</p>  
                  <p>His Comment is</p>
                  <p>{4}</p>
                  <p>Thank You and...</p>
                  <p><strong>the help Team</strong></p>
                  <hr />
                  <h2 style = ""color: #2e6c80;"" > &nbsp;</h2>
                  <p>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</p>
                  <p><strong>&nbsp;</strong></p>
                  <p>&nbsp;</p>
                  <p><strong>&nbsp;</strong></p>";

    public static string AdminBugReport = @"<h1 style=""color: #5e9ca0;"">Hey Admin</h1>
                  <h2 style = ""color: #2e6c80;"" >{0} Has written a Bug-Report: {1}</h2>
                  <p><h2>His Description is</h2></p>
                  <p>{2}</p>
				          <p><h2>Stack-Trace:</h2></p>
                  <p>{3}</p>
                  <p>Thank You and...</p>
                  <p><strong>the help Team</strong></p>
                  <hr />
                  <h2 style = ""color: #2e6c80;"" > &nbsp;</h2>
                  <p>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</p>
                  <p><strong>&nbsp;</strong></p>
                  <p>&nbsp;</p>
                  <p><strong>&nbsp;</strong></p>";

    public static string UserBugReport = @"<h1 style = ""color: #5e9ca0;"">Hey {0}</h1>
                  <h2 style = ""color: #2e6c80;"" >Thank you for writing Bug Report {1}</h2>
                  <p><h2>Your Description is</h2></p>
                  <p>{2}</p>
				          <p><h2>Your Stack-Trace:</h2></p>
                  <p>{3}</p>
                  <p>Thank You and...</p>
                  <p><strong>the help Team</strong></p>
                  <hr/>
                  <h2 style = ""color: #2e6c80;"" > &nbsp;</h2>
                  <p>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</p>
                  <p><strong>&nbsp;</strong></p>
                  <p>&nbsp;</p>
                  <p><strong>&nbsp;</strong></p>";

    public static string RequesterProposedArticle = @"<h1 style = ""color: #5e9ca0;"">Hey {0}</h1>
                  <h2 style = ""color: #2e6c80;"" >Thank you for writing Article Proposal {1}</h2>
                  <p><h2>Your Description is</h2></p>
                  <p>{2}</p>
				          <p><h2>Your Comment is:</h2></p>
                  <p>{3}</p>
                  <p>We will notfiy you if the Article gets created or something changed</p>
                  <p>Thank You and...</p>
                  <p><strong>the help Team</strong></p>
                  <hr/>
                  <h2 style = ""color: #2e6c80;"" > &nbsp;</h2>
                  <p>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</p>
                  <p><strong>&nbsp;</strong></p>
                  <p>&nbsp;</p>
                  <p><strong>&nbsp;</strong></p>";
  }
}