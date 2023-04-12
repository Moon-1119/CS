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
    public partial class FrmEdtMember : Form
    {
        private DTOMember member = null;
        public FrmEdtMember()
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
            DTOMember member = new DTOMember(
                txt_ID.Text,
                txt_Title.Text,
                txt_Author.Text,
                txt_e_mail.Text,
                Int32.Parse(txt_cnt.Text),
                txt_Date.Text,
                txt_Passward.Text,
                txt_Content.Text,
                Int32.Parse(txt_discover.Text)
                );

            return member;
        }
        public void SetMember(DTOMember edtMember)
        {
            this.member = edtMember;
            if ( member != null)
            {
                txt_ID.Text = member.ID;
                txt_Title.Text = member.Title;
                txt_Author.Text = member.Author;
                txt_e_mail.Text = member.e_mail;
                txt_cnt.Text = member.cnt;
                txt_Date.Text = member.Date;
                txt_Passward.Text = member.Passward;
                txt_Content.Text = member.Content;
                txt_discover.Text = member.discover;
            }
            this.Update(); // 데이터를 세팅만하고 그리지 않았기 때문에 업데이트
        }

    }
}
