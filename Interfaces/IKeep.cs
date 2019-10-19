namespace Keepr.Interfaces
{
  public interface IKeep
  {
    string Name { get; set; }
    string Description { get; set; }
    string Img { get; set; }
    bool isPrivate { get; set; }
    int Views { get; set; }
    int Shares { get; set; }
    int Keeps { get; set; }
    // int Id { get; set; }
  }
}


// Can Create Keep
// PATH: /keeps

// DATA: Keep object {name, description, img, isPrivate}

// RESPONSE: keep

// DESCRIPTION: Post request.This should create a keep in your database. Your backend should attach a userId.