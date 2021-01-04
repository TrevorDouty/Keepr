namespace keepr.Models
{
  public class Keep
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public int Count { get; set; }
    public int Id { get; set; }
    public string CreatorId { get; set; }
    public int Keeps { get; set; }
    public Profile Creator { get; set; }

  }

  public class VaultKeepViewModel : Keep
  {
    public int VaultKeepId { get; set; }
  }
}