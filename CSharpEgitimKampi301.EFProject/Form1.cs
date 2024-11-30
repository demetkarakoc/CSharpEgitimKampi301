using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();


        private void btnList_Click(object sender, EventArgs e)
        {
            
            var values= db.TblGuide.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TblGuide guide = new TblGuide();
            guide.GuideName = txtGuideName.Text;
            guide.GuideSurname = txtGuideSurname.Text;
            db.TblGuide.Add(guide);
            db.SaveChanges();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtGuideId.Text);
            var removeValue= db.TblGuide.Find(id);
            db.TblGuide.Remove(removeValue);
            db.SaveChanges();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id= int.Parse(txtGuideId.Text);
            var updateValue = db.TblGuide.Find(id);
            updateValue.GuideName = txtGuideName.Text;
            updateValue.GuideSurname= txtGuideSurname.Text;
            db.SaveChanges();
        }

        private void btnGetByID_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtGuideId.Text);
            var values = db.TblGuide.Where(x=>x.GuideId==id).ToList();
            dataGridView1.DataSource = values;


        }
    }
}
