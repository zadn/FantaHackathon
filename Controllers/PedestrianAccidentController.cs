using System.Collections.Generic;
using System.Threading.Tasks;
using FantaHackathon.Model;
using FantaHackathon.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FantaHackathon.Controllers
{
    [Route("api/Accident/Pedestrian")]
    public class PedestrianAccidentController : Controller
    {
        private readonly PedestrianRepository _pedestrianRepository;
        public PedestrianAccidentController()
        {
            _pedestrianRepository = new PedestrianRepository();
        }

        // GET api/Accident
        [HttpGet]
        public IEnumerable<Accident> Get() => _pedestrianRepository.GetAll();


        // // GET api/Accident/5
        // [HttpGet("{id}")]
        // public Accident Search(int id)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         return _pedestrianRepository.Search(id);
        //     }
        //     else return null;
        // }

        // POST api/Accident
        [HttpPost]
        public async Task Post([FromBody]Accident accdnt)
        {
            if (ModelState.IsValid)
                await _pedestrianRepository.Add(accdnt);
        }
    }

}


