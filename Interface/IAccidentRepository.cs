using System.Collections.Generic;
using FantaHackathon.Model;

namespace FantaHackathon.Interface
{

public interface IAccidentRepository
{
    IEnumerable<Accident> GetAll();
    void Add(Accident item);
    Accident Search(int item);
    void Update(Accident item1);
    Accident Delete(int item);    
    
}


}