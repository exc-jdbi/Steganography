 
namespace exc.jdbi.Steganographie;


public class StorageCapacitiesInfo
{
  public int RequiredCapacity = 0;
  public int StorageCapacities = 0;
  public int StorageCapacitiesL1 = 0;
  public int StorageCapacitiesL2 = 0;

  //Verzerrung der Wahrnehmung.
  //Image zeigt deutliche Veränderungen.
  public bool PerceptionDistortion = false;

  //Kapazität reicht aus oder nicht.
  public bool StorageCapacitiesVarify = false;
}