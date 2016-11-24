using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Servico.Controllers
{
    public class ContatoController : ApiController
    {

        public IEnumerable<Models.Contato> Get()
        {
            Models.AgendaDataContext dc = new Models.AgendaDataContext();
            var r1 = from r in dc.Contatos select r;
            return r1.ToList();
        }

        public void Post([FromBody] Models.Contato contato)
        {
            Models.AgendaDataContext dc = new Models.AgendaDataContext();
            dc.Contatos.InsertOnSubmit(new Models.Contato() { Nome = contato.Nome, Telefone = contato.Telefone });
            dc.SubmitChanges();
        }

        public void Put(int id, [FromBody] Models.Contato contato)
        {
            Models.AgendaDataContext dc = new Models.AgendaDataContext();
            Models.Contato cont = (from f in dc.Contatos where f.Id == id select f).Single();
            contato.Nome = contato.Nome;
            dc.SubmitChanges();
        }

        public void Delete(int id)
        {
            Models.AgendaDataContext dc = new Models.AgendaDataContext();
            Models.Contato c = (from f in dc.Contatos where f.Id == id select f).Single();
            dc.Contatos.DeleteOnSubmit(c);
            dc.SubmitChanges();
        }

    }
}
