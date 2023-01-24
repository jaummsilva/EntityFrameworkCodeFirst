using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkCodeFirst;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace MVC
{
    public class CarrosController : Controller
    {
        private BaseContext db = new BaseContext();

        // GET: Carros
        public ActionResult Index()
        {
            return View(db.Carros.ToList());
        }

        public ActionResult Pdf()
        {
            Document doc = new Document(PageSize.A4);
            doc.SetMargins(40, 40, 40, 80);
            doc.AddCreationDate();
            string caminho = AppDomain.CurrentDomain.BaseDirectory + @"\pdf\" + "relatorio.pdf";

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));

            doc.Open();

            Paragraph titulo = new Paragraph();
            titulo.Font = new Font(Font.FontFamily.COURIER, 40);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.Add("Testeee");
            doc.Add(titulo);

            Paragraph paragrafo = new Paragraph("", new Font(Font.NORMAL, 12));
            string conteudo = "Lorem Ipsum is simply dummy text of printing.\n\n";
            paragrafo.Add(conteudo);
            doc.Add(paragrafo);

            PdfPTable table = new PdfPTable(3);

            table.AddCell("Linha 1 ,Coluna 1");
            table.AddCell("Linha 1 ,Coluna 2");
            table.AddCell("Linha 1 ,Coluna 3");

            table.AddCell("Linha 2 ,Coluna 1");
            table.AddCell("Linha 2 ,Coluna 2");
            table.AddCell("Linha 2 ,Coluna 3");

            doc.Add(table);
            doc.Close();

            return Redirect("/pdf/relatorio.pdf");


        }

        // GET: Carros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = db.Carros.Find(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // GET: Carros/Create
        public ActionResult Create()
        {
            ViewBag.ModeloId = new SelectList(db.Modelos, "Id", "Nome");
            return View();
        }

        // POST: Carros/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,ModeloId,Ano")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                db.Carros.Add(carro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ModeloId = new SelectList(db.Modelos, "Id", "Nome", carro.ModeloId);
            return View(carro);
        }

        // GET: Carros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = db.Carros.Find(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModeloId = new SelectList(db.Modelos, "Id", "Nome", carro.ModeloId);
            return View(carro);
        }

        // POST: Carros/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,ModeloId,Ano")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ModeloId = new SelectList(db.Modelos, "Id", "Nome", carro.ModeloId);
            return View(carro);
        }

        // GET: Carros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = db.Carros.Find(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // POST: Carros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carro carro = db.Carros.Find(id);
            db.Carros.Remove(carro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
