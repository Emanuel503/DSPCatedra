using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using veterinaria.Models;

namespace veterinaria.Controllers
{
    public class mascotasWebApiController : ApiController
    {
        private veterinariaEntities db = new veterinariaEntities();

        // GET: api/mascotasWebApi
        public IQueryable<mascota> Getmascota()
        {
            return db.mascota;
        }

        // GET: api/mascotasWebApi/5
        [ResponseType(typeof(mascota))]
        public IHttpActionResult Getmascota(int id)
        {
            mascota mascota = db.mascota.Find(id);
            if (mascota == null)
            {
                return NotFound();
            }

            return Ok(mascota);
        }

        // PUT: api/mascotasWebApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putmascota(int id, mascota mascota)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mascota.idMascota)
            {
                return BadRequest();
            }

            db.Entry(mascota).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!mascotaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/mascotasWebApi
        [ResponseType(typeof(mascota))]
        public IHttpActionResult Postmascota(mascota mascota)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.mascota.Add(mascota);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mascota.idMascota }, mascota);
        }

        // DELETE: api/mascotasWebApi/5
        [ResponseType(typeof(mascota))]
        public IHttpActionResult Deletemascota(int id)
        {
            mascota mascota = db.mascota.Find(id);
            if (mascota == null)
            {
                return NotFound();
            }

            db.mascota.Remove(mascota);
            db.SaveChanges();

            return Ok(mascota);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool mascotaExists(int id)
        {
            return db.mascota.Count(e => e.idMascota == id) > 0;
        }
    }
}