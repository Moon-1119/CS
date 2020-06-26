using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp_DB_Final.DTO;

namespace WindowsFormsApp_DB_Final
{
    public partial class FrmNewMember : Form
    {
        public FrmNewMember()
        {
            InitializeComponent();
        }

        // OK버튼을 눌렀을 때 입력되었던 정보를 끌어다가 추가해야 함
        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public DTOMember GetMember()
        {
            DateTime dtNow = DateTime.Now;
            DTOMember member = new DTOMember(
                txt_ID.Text,
                txt_Title.Text,
                txt_Author.Text,
                txt_e_mail.Text,
                0,
                dtNow.ToString("yyyyMMddHHmmss"),
                txt_Passward.Text,
                txt_Content.Text,
                1
                );

            return member;
        }

    }
}
