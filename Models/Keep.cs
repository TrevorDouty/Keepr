namespace keepr.Models
{
  public class Keep
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public string Img { get; set; }
    public int KeepCount { get; set; }
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