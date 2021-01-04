namespace keepr.Models
{
  public class Vault
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public bool isPrivate { get; set; }
    public int Id { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
  }


}