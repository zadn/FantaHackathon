﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FantaHackathon.Model;
using FantaHackathon.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FantaHackathon.Controllers
{
    [Route("api/Accident")]
    public class AccidentController : Controller
       {
        private readonly AccidentRepository _accidentRepository;
        public AccidentController()
        {
            _accidentRepository = new AccidentRepository();
        }

        // GET api/Accident
        [HttpGet]
        public IEnumerable<Accident> Get() => _accidentRepository.GetAll();
        

        // GET api/Accident/5
        [HttpGet("{id}")]
        public Accident Search(int id)
        {
            if (ModelState.IsValid)
            {
                return _accidentRepository.Search(id);
            }
            else return null;
        }

        // POST api/Accident
        [HttpPost]
        public void Post([FromBody]Accident accdnt)
        {
            if (ModelState.IsValid)
                _accidentRepository.Add(accdnt);
        }

        // PUT api/Accident/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Accident accdnt)
        {
            accdnt.Id = id;
            if (ModelState.IsValid)
                _accidentRepository.Update(accdnt);
        }

        // DELETE api/Accident/5
        [HttpDelete("{id}")]
        public Accident Delete(int id)
        {

            if (ModelState.IsValid)
            {
                return _accidentRepository.Delete(id);
            }
            else return null;
        }
    }
}