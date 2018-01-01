using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FantaHackathon.Model;

namespace FantaHackathon.Interface
{

public interface IAccidentRepository
{
    Task<String> GetPlaceName(double lat, double lon);
    IEnumerable<Accident> GetAll();
    Task Add(Accident item);
    Accident Search(int item);
    void Update(Accident item1);
    Accident Delete(int item);    
    
}


}