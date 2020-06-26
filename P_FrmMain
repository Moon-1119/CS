using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsDBTest.DAO;
using WindowsFormsDBTest.DTO;

namespace WindowsFormsDBTest
{
    enum DB_ERROR
    {
        ERR_SUCCESS,
        ERR_DB_CONNECTION_ERROR,
        ERR_DB_READ_ERROR,
        ERR_DB_ERROR_NONE
    };

    public partial class FrmMain : Form
    {

        private MySqlConnection conn = null;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if( DB_Connect())
            {
                btnConnect.Enabled = false;
                btnRead.Enabled = true;
                btnClose.Enabled = true;
                btnDelete.Enabled = true;
                btnNew.Enabled = true;
                btnEdit.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DB_Disconnect();

            btnConnect.Enabled = true;
            btnRead.Enabled = false;
            btnClose.Enabled = false;
            btnDelete.Enabled = false;
            btnNew.Enabled = false ;
            btnEdit.Enabled = false;
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            String message = null;
            switch( DB_Read( ref message))
            {
                case DB_ERROR.ERR_SUCCESS: break;
                case DB_ERROR.ERR_DB_CONNECTION_ERROR: MessageBox.Show("데이터베이스에 연결되지 않았습니다.");                     break;
                case DB_ERROR.ERR_DB_READ_ERROR:       Console.WriteLine(message);
                                                            MessageBox.Show(message);                               break;
                default: break;
            }

        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DB_Disconnect();
        }

        private bool DB_Connect()
        {
            string connstr = "Server=127.0.0.1;port=3306;Database=db_inu01;Uid=root;Pwd=0273;allow user variables=true";

            if (conn == null)
            {
                conn = new MySqlConnection(connstr);
            }

            try
            {
                conn.Open();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        private void DB_Disconnect()
        {
            try
            {
                if (conn != null)
                {
                    conn.Close();
                    conn = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmNewMember frmNewMember = new FrmNewMember();

            if (DialogResult.Cancel == frmNewMember.ShowDialog())
            {
                return;
            }
            DTO.DtoMember newMember = frmNewMember.GetMember();
            DB_Insert(newMember);

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DB_Edit();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection idxColl = listMember.SelectedIndices;

            for(int i = 0; i < idxColl.Count; i++)
            {
                Console.WriteLine(idxColl.ToString());
                int idx = idxColl[i];

                Console.WriteLine(listMember.Items[idx].ToString());
                DB_Delete(idx);

            }
        }

        //===================================================================//


        private void DB_Insert(DtoMember newMember)
        {
            String errMsg = "";
            DB_ERROR errCode = DB_ERROR.ERR_DB_ERROR_NONE;

            if( 0 >= DaoMember.InsertMember(newMember, conn, ref errCode, ref errMsg) )
            {
                MessageBox.Show(errMsg);
            }
        }

        private DB_ERROR DB_Read(ref String errMsg)
        {
            if (conn == null)
            {

                return DB_ERROR.ERR_DB_CONNECTION_ERROR;
            }


            try
            {
                listMember.Items.Clear();

                DB_ERROR errCode = DB_ERROR.ERR_DB_ERROR_NONE;

                List<DtoMember> lst = DaoMember.SelectAllMember(conn, ref errCode, ref errMsg);

                foreach (DtoMember member in lst)
                {

                    ListViewItem newItm = new ListViewItem(new String[] {
                        member.id,
                        member.title,
                        member.author,
                        member.e_mail,
                        member.cnt.ToString(),
                        member.date,
                        member.password,
                        member.content
                    });

                    listMember.Items.Add(newItm);
                }


            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return DB_ERROR.ERR_DB_READ_ERROR;
            }

            return DB_ERROR.ERR_SUCCESS;
        }


        private void DB_Edit()
        {
            ListView.SelectedIndexCollection idxColl = listMember.SelectedIndices;

            if (idxColl.Count <= 0)
            {
                return;
            }
            Console.WriteLine(idxColl.ToString());
            int idx = idxColl[0];

            //listMember.Items[idx].Text;
            Console.WriteLine(listMember.Items[idx].ToString());

            DB_ERROR errCode = DB_ERROR.ERR_DB_ERROR_NONE;
            String errMsg = null; ;

            DtoMember edtMember = DaoMember.SelectOneMember(Int32.Parse(listMember.Items[idx].Text), conn, ref errCode, ref errMsg);

            if (edtMember == null)
            {
                return;
            }

            FrmEdtMember frmEdtMember = new FrmEdtMember();
            frmEdtMember.SetMember(edtMember);

            if (DialogResult.Cancel == frmEdtMember.ShowDialog())
            {
                return;
            }

            DaoMember.UpdateOneMember(edtMember, conn, ref errCode, ref errMsg);
        }


        private void DB_Delete(int idx)
        {
            String errMsg = "";
            DB_ERROR errCode = DB_ERROR.ERR_DB_ERROR_NONE;

            if (0 >= DaoMember.UpdateMemberNoochool(Int32.Parse(listMember.Items[idx].Text), conn, ref errCode, ref errMsg))
            {
                MessageBox.Show(errMsg);
            }
        }

    }
}

// FrmNewMember
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WindowsFormsDBTest.DTO;

namespace WindowsFormsDBTest
{
    public partial class FrmNewMember : Form
    {

        public FrmNewMember()
        {
            InitializeComponent();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public DtoMember GetMember()
        {
            DateTime dtNow = DateTime.Now;

            DtoMember newMember = new DtoMember(
                txtID.Text,
                txtTitle.Text,
                txtAuthor.Text,
                txtEmail.Text,
                0,
                dtNow.ToString("yyyyMMddHHmmss"),
                txtPW.Text,
                txtContent.Text
                );


            return newMember;
        }
    }
}

// FrmEdtMember
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WindowsFormsDBTest.DTO;

namespace WindowsFormsDBTest
{
    public partial class FrmEdtMember : Form
    {
        private DtoMember member = null;
        public FrmEdtMember()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetMember(DtoMember member)
        {
            this.member = member;

            if (member != null)
            {
                txtID.Text = member.id;
                txtTitle.Text = member.title;
                txtAuthor.Text = member.author;
                txtEmail.Text = member.e_mail;
                txtCnt.Text = member.cnt.ToString();
                txtDate.Text = member.date;
                txtPW.Text = member.password;
                txtContent.Text = member.content;
                txtNochool.Text = member.nochool.ToString(); ;
            }
            this.Update();
        }
        public DtoMember GetMember()
        {

            DtoMember edtMember = new DtoMember(
                txtID.Text,
                txtTitle.Text,
                txtAuthor.Text,
                txtEmail.Text,
                Int32.Parse(txtCnt.Text),
                txtDate.Text,
                txtPW.Text,
                txtContent.Text,
                Int32.Parse(txtNochool.Text)
                );


            return edtMember;
        }
    }
}

// DTOMember
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsDBTest.DTO
{
    public class DtoMember
    {
        public String id;
        public String title;
        public String author;
        public String e_mail;
        public int cnt;
        public String date;
        public String password;
        public String content;
        public int nochool;
        public DtoMember(String id,
            String title,
            String author,
            String e_mail,
            int cnt,
            String date,
            String password,
            String content
            )
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.e_mail = e_mail;
            this.cnt = cnt;
            this.date = date;
            this.password = password;
            this.content = content;

        }

        public DtoMember(String id,
            String title,
            String author,
            String e_mail,
            int cnt,
            String date,
            String password,
            String content,
            int nochool
            )
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.e_mail = e_mail;
            this.cnt = cnt;
            this.date = date;
            this.password = password;
            this.content = content;
            this.nochool = nochool;
        }
    }
}

// DAOMember
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsDBTest.DTO;


namespace WindowsFormsDBTest.DAO
{
    class DaoMember
    {

        public static List<DtoMember> SelectAllMember(MySqlConnection conn, ref DB_ERROR error, ref String errMsg)
        {
            List<DtoMember> lst = new List<DtoMember>();

            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "SELECT * FROM tb_member Where nochool = 1 ";

            try
            {

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7}",
                        reader["id"].ToString(),
                        reader["title"].ToString(),
                        reader["author"].ToString(),
                        reader["e_mail"].ToString(),
                        reader["cnt"].ToString(),
                        reader["date"].ToString(),
                        reader["password"].ToString(),
                        reader["content"].ToString()
                        );
                    /*                    Console.WriteLine(reader["id"].ToString());
                                        Console.WriteLine(reader["title"].ToString());
                                        Console.WriteLine(reader["author"].ToString());
                                        Console.WriteLine(reader["cnt"].ToString());
                                        Console.WriteLine(reader["date"].ToString());
                                        Console.WriteLine(reader["password"].ToString());
                                        Console.WriteLine(reader["content"].ToString());*/

                    DtoMember member = new DtoMember(
                        reader["id"].ToString(),
                        reader["title"].ToString(),
                        reader["author"].ToString(),
                        reader["e_mail"].ToString(),
                        Int32.Parse(reader["cnt"].ToString()),
                        reader["date"].ToString(),
                        reader["password"].ToString(),
                        reader["content"].ToString()
                    );

                    lst.Add(member);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                error = DB_ERROR.ERR_DB_READ_ERROR;
            }

            error = DB_ERROR.ERR_SUCCESS;
            return lst;
        }

        public static DtoMember SelectOneMember(int id, MySqlConnection conn, ref DB_ERROR error, ref String errMsg)
        {
            DtoMember member = null;
            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "SELECT * FROM tb_member Where id = @id";
           
            cmd.Parameters.Add("@id", MySqlDbType.Int32, 11);
            cmd.Parameters["@id"].Value = id;

            MySqlDataReader reader = cmd.ExecuteReader();
            if (false == reader.Read())
            {
                reader.Close();
                error = DB_ERROR.ERR_DB_READ_ERROR;
                return null;
            }

            member = new DtoMember(
            reader["id"].ToString(),
            reader["title"].ToString(),
            reader["author"].ToString(),
            reader["e_mail"].ToString(),
            Int32.Parse(reader["cnt"].ToString()),
            reader["date"].ToString(),
            reader["password"].ToString(),
            reader["content"].ToString(),
            Int32.Parse(reader["nochool"].ToString())
            );

            reader.Close();

            return member;
        }

        public static int UpdateOneMember(DtoMember member, MySqlConnection conn, ref DB_ERROR error, ref String errMsg)
        {
            if(member == null )
            {
                return 0;
            }

            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "UPDATE tb_member SET title = @title, cnt = @cnt, password = @pw, content = @content, nochool = @nochool WHERE id = @id";
            try
            {
                cmd.Parameters.Add("@id", MySqlDbType.Int32, 11);
                cmd.Parameters["@id"].Value = member.id;

                cmd.Parameters.Add("@title", MySqlDbType.VarChar, 50);
                cmd.Parameters["@title"].Value = member.title;

                cmd.Parameters.Add("@cnt", MySqlDbType.Int32, 10);
                cmd.Parameters["@cnt"].Value = member.cnt;

                cmd.Parameters.Add("@pw", MySqlDbType.VarChar, 30);
                cmd.Parameters["@pw"].Value = member.password;

                cmd.Parameters.Add("@content", MySqlDbType.VarChar, 1000);
                cmd.Parameters["@content"].Value = member.content;

                cmd.Parameters.Add("@nochool", MySqlDbType.Int32, 11);
                cmd.Parameters["@nochool"].Value = member.nochool;

                Int32 rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine("RowsAffected: {0}", rowsAffected);

                return rowsAffected;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return 0;
        }


        public static int InsertMember(DtoMember newMember, MySqlConnection conn, ref DB_ERROR error, ref String errMsg)
        {
            try
            {
                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "INSERT INTO tb_member(id, title, author, e_mail, cnt, date, password, content, nochool) VALUES(@id, @title, @author, @email, @cnt, @date, @pw, @content, 1);";

                cmd.Parameters.Add("@id", MySqlDbType.Int32, 11);
                cmd.Parameters["@id"].Value = newMember.id;

                cmd.Parameters.Add("@title", MySqlDbType.VarChar, 50);
                cmd.Parameters["@title"].Value = newMember.title;

                cmd.Parameters.Add("@author", MySqlDbType.VarChar, 30);
                cmd.Parameters["@author"].Value = newMember.author;

                cmd.Parameters.Add("@email", MySqlDbType.VarChar, 60);
                cmd.Parameters["@email"].Value = newMember.e_mail;

                cmd.Parameters.Add("@cnt", MySqlDbType.Int32, 10);
                cmd.Parameters["@cnt"].Value = newMember.cnt;

                cmd.Parameters.Add("@date", MySqlDbType.VarChar, 14);
                cmd.Parameters["@date"].Value = newMember.date;

                cmd.Parameters.Add("@pw", MySqlDbType.VarChar, 30);
                cmd.Parameters["@pw"].Value = newMember.password;

                cmd.Parameters.Add("@content", MySqlDbType.VarChar, 1000);
                cmd.Parameters["@content"].Value = newMember.content;

                Int32 rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine("RowsAffected: {0}", rowsAffected);
                
                return rowsAffected;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return 0;
        }

        public static int UpdateMemberNoochool(int id, MySqlConnection conn, ref DB_ERROR error, ref String errMsg)
        {
            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "UPDATE tb_member SET nochool = 0 WHERE id = @id";
            cmd.Parameters.Add("@id", MySqlDbType.Int32, 11);
            cmd.Parameters["@id"].Value = id;

            try
            {
                Int32 rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine("RowsAffected: {0}", rowsAffected);

                return rowsAffected;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }
    }
}

