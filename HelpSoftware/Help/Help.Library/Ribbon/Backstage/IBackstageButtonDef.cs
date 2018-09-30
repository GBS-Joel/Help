using Help.EF;

namespace Help.Library
{
  public interface IBackstageButtonDef
  {
    BackstageButtonDef BackstageButtonDef { get; set; }

    BackstageButtonDef GetBackStageButtonDef();
  }
}