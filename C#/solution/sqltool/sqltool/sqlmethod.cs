using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace sqltoolkit
{
    class sqlmethod
    {
        static string dbPath = "Data Source =" + Environment.CurrentDirectory + "/test.db3"+";Version=3;";
        static SQLiteConnection con = null;


        public sqlmethod() //构造函数
        {
            connect2database();
        }

        public void connect2database()
        {
            try
            {
                //创建连接数据库实例，指定文件位置 
                con = new SQLiteConnection(dbPath);
                //打开数据库，若文件不存在会自动创建 
                con.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;     
            }                       
        }
        public void writesql()
        {
            //string dbPath = "Data Source =" + Environment.CurrentDirectory + "/test.db"+";Verson=3;";
            con = new SQLiteConnection(dbPath);
            con.Open();
            string sql = "CREATE TABLE IF NOT EXISTS student(id integer, name varchar(20), sex varchar(2));";
            SQLiteCommand com = new SQLiteCommand(sql, con);//建表语句 
            Console.WriteLine(com.ExecuteNonQuery());//执行sql指令创建建数据表,如果表不存在，创建数据表,成功返回-1 
            //给表添加数据
            //1. 使用sql语句逐行添加
            com.CommandText = "INSERT INTO student VALUES(1, '小红', '男')";
            Console.WriteLine(com.ExecuteNonQuery());
            Console.ReadKey();
            con.Close();
        }
        public int writesql(string sqlcmd) //重载
        {
            con = new SQLiteConnection(dbPath);
            con.Open();
            SQLiteCommand com = new SQLiteCommand(sqlcmd, con);
            //com.CommandText = sqlcmd
            int writestatus = 0;
            writestatus = com.ExecuteNonQuery();
            Console.Write(writestatus);
            con.Close();
            return writestatus;
        }

        public void writesqlbytran()
        {
            //2. 使用事务添加
            //实例化一个事务对象
            con = new SQLiteConnection(dbPath);
            con.Open();
            SQLiteTransaction tran = con.BeginTransaction();
            SQLiteCommand com = new SQLiteCommand();
            //把事务对象赋值给com的transaction属性
            com.Transaction = tran;
            //设置带参数sql语句
            com.CommandText = "INSERT INTO student VALUES(@id, @name, @sex)";
            for (int i = 0; i < 10; i++)
            {
                //添加参数
                com.Parameters.AddRange(new[] {//添加参数 
               new SQLiteParameter("@id", i + 1),
               new SQLiteParameter("@name", "hello" + i),
               new SQLiteParameter("@sex", i % 3 == 0 ? "男" : "女")
           });
                //执行添加
                com.ExecuteNonQuery();
            }
            //提交事务
            tran.Commit();
            //关闭数据库
            con.Close();
        }

        public void querysql()
        {
            string sql = "select * from student";
            con = new SQLiteConnection(dbPath);
            con.Open();
            SQLiteCommand cmdQ = new SQLiteCommand(sql, con);
            SQLiteDataReader reader = cmdQ.ExecuteReader();
            //richTextBox1.Text = "";
            string Text = "";
            while (reader.Read())
            {
                //读取并赋值
                
                Text = reader.GetInt32(0) + " " + reader.GetString(1) + " " + reader.GetString(2) + "\n";
                Console.WriteLine(Text);
            }
            //关闭数据库
            
            Console.ReadKey();
            con.Close();
            
        }
    }
}
