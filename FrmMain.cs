using MySql.Data.MySqlClient;
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
    //에러코드 관리
    enum DB_READ_ERROR
    {
        ERR_SUCCESS,
        ERR_DB_CONNECTION_ERROR,
        ERR_DB_READ_ERROR,
        ERR_MAX,
    }

    public partial class FrmMain : Form
    {
        //접근성을 위해 밖에서 선언
        private MySqlConnection conn = null;
        public FrmMain()
        {
            InitializeComponent();
        }
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (false == DB_Connect())
            {
                return;
            }

            btn_Connect.Enabled = false;
            btn_Disconnect.Enabled = true;
            btn_Read.Enabled = true;
            btn_Delete.Enabled = true;
            btn_New.Enabled = true;
            btn_Edit.Enabled = true;
        }

        private void btn_Disconnect_Click(object sender, EventArgs e)
        {
            DB_Disconnect();

            btn_Connect.Enabled = true;
            btn_Disconnect.Enabled = false;
            btn_Read.Enabled = false;
            btn_Delete.Enabled = false;
            btn_New.Enabled = false;
            btn_Edit.Enabled = false;
        }

        private void btn_Read_Click(object sender, EventArgs e)
        {
            String errMsg = null;
            switch (DB_Read(ref errMsg))
            {
                // 0 1 2 는 매직넘버이기 때문에 enum으로 관리
                case DB_READ_ERROR.ERR_SUCCESS: break; // 오류발생 x do nothing
                case DB_READ_ERROR.ERR_DB_CONNECTION_ERROR: MessageBox.Show("DB에 연결되지 않았습니다.", "Error"); break; // 오류 1
                case DB_READ_ERROR.ERR_DB_READ_ERROR: MessageBox.Show(errMsg); break; // 오류 2
                default: break;

            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DB_Disconnect();
        }

        private bool DB_Connect()
        {
            // 객체를 할당
            // conn은 스택변수지만 new로 생성하여 실제 값은 힙에 할당
            // conn이 garbage collector에 의해 삭제될 수 있음
            // connection을 유지하기 위해서는 외부에서도 conn에 접근이 가능해야함
            if (conn != null) // null인 경우만 연결 (상단에서 에러를 다루는게 중요)
            {
                MessageBox.Show("DB에 이미 연결되었습니다.", "Error");
                return true;
            }
            string connstr = "Server=127.0.0.1;port=3306;Database=db_inu01;Uid=root;Pwd=0273;allow user variables=true";
            conn = new MySqlConnection(connstr);
            try
            {
                conn.Open();//mysqlconnection의 public멤버함수 호출
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void DB_Disconnect()
        {
            if (conn == null)
            {
                return;
            }
            conn.Close();
            conn = null;
        }

        //각각 return값을 설정하여 나눔
        private DB_READ_ERROR DB_Read(ref String errMsg)
        {
            if (conn == null)
            {
                return DB_READ_ERROR.ERR_DB_CONNECTION_ERROR; ;
            }
            // sql은 명령어라 커맨드 객체를 만들어주고 커맨드 텍스트를 통해 쿼리 실행
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM tb_member";
            try
            {
                // read를 반복할 시 출력이 중복되기 때문에 클리어 필요
                list_Member.Items.Clear();

                // 연결 후 reader를 만들어줌
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8}",
                        reader["id"].ToString(),
                        reader["title"].ToString(),
                        reader["author"].ToString(),
                        reader["e_mail"].ToString(),
                        reader["cnt"].ToString(),
                        reader["date"].ToString(),
                        reader["passward"].ToString(),
                        reader["content"].ToString(),
                        reader["discover"].ToString()
                        );
                    // 리스트로 윈도우폼 화면에 출력
                    ListViewItem newItm = new ListViewItem(new String[] {
                        reader["id"].ToString(),
                        reader["title"].ToString(),
                        reader["author"].ToString(),
                        reader["e_mail"].ToString(),
                        reader["cnt"].ToString(),
                        reader["date"].ToString(),
                        reader["passward"].ToString(),
                        reader["content"].ToString(),
                        reader["discover"].ToString()
                    });
                    list_Member.Items.Add(newItm);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                errMsg = ex.Message;
                return DB_READ_ERROR.ERR_DB_READ_ERROR;
            }
            return DB_READ_ERROR.ERR_SUCCESS; ;
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            // collection = 배열
            ListView.SelectedIndexCollection idxColl = list_Member.SelectedIndices;

            // for문을 이용해서 배열안의 개수만큼 돌림
            for (int i = 0; i < idxColl.Count; i++)
            {
                // 생성된 배열의 i번째 원소
                // 선택된 것이 list_Member의 items의 몇번째 인덱스인지 가져옴 
                int idx = idxColl[i];
                MySqlCommand cmd = conn.CreateCommand();
                // 선택된 아이디의 discover를 0으로
                cmd.CommandText = "UPDATE tb_member SET discover = 0 WHERE id =" + list_Member.Items[idx].Text;

                try
                {
                    cmd.ExecuteNonQuery(); // update, delete, insert는 excute만 시행
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            FrmNewMember frmnewMember = new FrmNewMember();
            // 새 창이 뜨고 그 뒤에 창은 사용 불가 (showDialog)
            if (DialogResult.OK == frmnewMember.ShowDialog())
            {
                Console.WriteLine("Cancel");
                return;
            }
            // form으로부터 받아와서 insert
            DTO.DTOMember newMember = frmnewMember.GetMember();

            DB_Insert(newMember);

        }

        private void DB_Insert(DTOMember newMember)
        {
            MySqlCommand cmd = conn.CreateCommand();
            try
            {
                cmd.CommandText = "INSERT INTO tb_member(ID, Title, Author, e_mail, cnt, DATE, Passward, Content, discover) " +
                "VALUES(@ID, @Title, @Author, @e_mail, @cnt, @Date, @Passward, @Content, @discover); ";

                // 커맨드를 이용해 @ID를 파라미터 객체로 대신함
                cmd.Parameters.Add("@ID", MySqlDbType.Int32, 11);
                cmd.Parameters["@ID"].Value = newMember.ID;

                cmd.Parameters.Add("@Title", MySqlDbType.VarChar, 50);
                cmd.Parameters["@Title"].Value = newMember.Title;

                cmd.Parameters.Add("@Author", MySqlDbType.VarChar, 30);
                cmd.Parameters["@Author"].Value = newMember.Author;

                cmd.Parameters.Add("@e_mail", MySqlDbType.VarChar, 60);
                cmd.Parameters["@e_mail"].Value = newMember.e_mail;

                cmd.Parameters.Add("@cnt", MySqlDbType.Int32, 10);
                cmd.Parameters["@cnt"].Value = newMember.cnt;

                cmd.Parameters.Add("@Date", MySqlDbType.VarChar, 14);
                cmd.Parameters["@Date"].Value = newMember.Date;

                cmd.Parameters.Add("@Passward", MySqlDbType.VarChar, 30);
                cmd.Parameters["@Passward"].Value = newMember.Passward;

                cmd.Parameters.Add("@Content", MySqlDbType.VarChar, 1000);
                cmd.Parameters["@Content"].Value = newMember.Content;

                cmd.Parameters.Add("@discvoer", MySqlDbType.Int32, 11);
                cmd.Parameters["@discover"].Value = newMember.Content;

                // 몇개의 로그가 영향받고있는지 표시
                Int32 rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine("RowsAffected: {0}", rowsAffected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            // collection = 배열
            ListView.SelectedIndexCollection idxColl = list_Member.SelectedIndices;

            // for문을 이용해서 배열안의 개수만큼 돌림
            if (idxColl.Count <= 0)
            {
                return;
            }

            // 생성된 배열의 i번째 원소
            // 선택된 것이 list_Member의 items의 몇번째 인덱스인지 가져옴 
            int idx = idxColl[0];
            MySqlCommand cmd = conn.CreateCommand();
            // 선택된 아이디의 discover를 0으로
            cmd.CommandText = "SELECT * FROM tb_member WHERE id =" + list_Member.Items[idx].Text;
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                DTOMember edtMember = new DTOMember(
                reader["id"].ToString(),
                reader["title"].ToString(),
                reader["author"].ToString(),
                reader["e_mail"].ToString(),
                Int32.Parse(reader["cnt"].ToString()),
                reader["date"].ToString(),
                reader["passward"].ToString(),
                reader["content"].ToString(),
                Int32.Parse(reader["discover"].ToString())
                );
                reader.Close();

                FrmEdtMember frmEdtMember = new FrmEdtMember();
                frmEdtMember.SetMember(edtMember);

                if ( DialogResult.Cancel == frmEdtMember.ShowDialog())
                {
                    return;
                }

                cmd.CommandText = "UPDATE tb_member SET" +
                    "Title = @Title, " +
                    "cnt = @cnt," +
                    "Passward = @Passward," +
                    "Content = @Content," +
                    "discover = @discoer," +
                    "WHERE ID = @ID";

                edtMember = frmEdtMember.GetMember();

                try
                {
                    // 커맨드를 이용해 @ID를 파라미터 객체로 대신함
                    cmd.Parameters.Add("@ID", MySqlDbType.Int32, 11);
                    cmd.Parameters["@ID"].Value = edtMember.ID;

                    cmd.Parameters.Add("@Title", MySqlDbType.VarChar, 50);
                    cmd.Parameters["@Title"].Value = edtMember.Title;

                    cmd.Parameters.Add("@cnt", MySqlDbType.Int32, 10);
                    cmd.Parameters["@cnt"].Value = edtMember.cnt;

                    cmd.Parameters.Add("@Passward", MySqlDbType.VarChar, 30);
                    cmd.Parameters["@Passward"].Value = edtMember.Passward;

                    cmd.Parameters.Add("@Content", MySqlDbType.VarChar, 1000);
                    cmd.Parameters["@Content"].Value = edtMember.Content;

                    cmd.Parameters.Add("@discvoer", MySqlDbType.Int32, 11);
                    cmd.Parameters["@discover"].Value = edtMember.Content;

                    // 몇개의 로그가 영향받고있는지 표시
                    Int32 rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine("RowsAffected: {0}", rowsAffected);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }

        }
    }   
}
