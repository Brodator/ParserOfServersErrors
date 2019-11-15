using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;
using DuoVia.FuzzyStrings;
namespace ParseR
{
    public partial class Form1 : Form
    {
        static List<ErrorModel> errorModels = new List<ErrorModel>();
        public static List<string> parsedData = new List<string>();
        public static List<CompleteError> completeErrors = new List<CompleteError>();


        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Full-text Date search_________________________________________________________________________________
            int searchOutput = 0;
            string query = textBox1.Text.Trim();
            for (int i = 0; i < errorModels.Count; i++)
            {
                if (query == "" || query == " ")
                {
                    MessageBox.Show("Вы не ввели текст в строку поиска по дате!");
                    break;
                }
                if (radioButton2.Checked)
                {
                    if (errorModels[i].error.Contains(query) && errorModels[i].error.Length == query.Length)
                    {

                        //stringBuilder.Append(errorModels[i].date + '\r' + '\n');
                        DataGridViewRow row = dataGridView1.Rows[i];

                        var date = dataGridView1.Rows[searchOutput].Cells["date"].Value;
                        var error = dataGridView1.Rows[searchOutput].Cells["error"].Value;
                        var sourceError = dataGridView1.Rows[searchOutput].Cells["sourceError"].Value;
                        var stackTrace = dataGridView1.Rows[searchOutput].Cells["stackTrace"].Value;

                        dataGridView1.Rows[searchOutput].Cells["date"].Value = row.Cells["date"].Value;
                        dataGridView1.Rows[searchOutput].Cells["error"].Value = row.Cells["error"].Value;
                        dataGridView1.Rows[searchOutput].Cells["sourceError"].Value = row.Cells["sourceError"].Value;
                        dataGridView1.Rows[searchOutput].Cells["stackTrace"].Value = row.Cells["stackTrace"].Value;

                        row.Cells["date"].Value = date;
                        row.Cells["error"].Value = error;
                        row.Cells["sourceError"].Value = sourceError;
                        row.Cells["stackTrace"].Value = stackTrace;

                        var papaparsedData = completeErrors[searchOutput];
                        completeErrors[searchOutput] = completeErrors[i];
                        completeErrors[i] = papaparsedData;

                        searchOutput++;

                    }
                    else if (StringExtensions.FuzzyEquals(query, errorModels[i].error, 0.4) || errorModels[i].error.Contains(query))//StringExtensions.FuzzyEquals(query, errorModels[i].date, 0.3) || StringExtensions.FuzzyEquals(query, errorModels[i].error, 0.4)
                    {

                        DataGridViewRow row = dataGridView1.Rows[i];

                        var date = dataGridView1.Rows[searchOutput].Cells["date"].Value;
                        var error = dataGridView1.Rows[searchOutput].Cells["error"].Value;
                        var sourceError = dataGridView1.Rows[searchOutput].Cells["sourceError"].Value;
                        var stackTrace = dataGridView1.Rows[searchOutput].Cells["stackTrace"].Value;

                        dataGridView1.Rows[searchOutput].Cells["date"].Value = row.Cells["date"].Value;
                        dataGridView1.Rows[searchOutput].Cells["error"].Value = row.Cells["error"].Value;
                        dataGridView1.Rows[searchOutput].Cells["sourceError"].Value = row.Cells["sourceError"].Value;
                        dataGridView1.Rows[searchOutput].Cells["stackTrace"].Value = row.Cells["stackTrace"].Value;

                        row.Cells["date"].Value = date;
                        row.Cells["error"].Value = error;
                        row.Cells["sourceError"].Value = sourceError;
                        row.Cells["stackTrace"].Value = stackTrace;

                        var papaparsedData = completeErrors[searchOutput];
                        completeErrors[searchOutput] = completeErrors[i];
                        completeErrors[i] = papaparsedData;

                        searchOutput++;
                    }
                }
                if (radioButton3.Checked)
                {
                    if(errorModels[i].sourceError.Contains(query))
                    {
                        DataGridViewRow row = dataGridView1.Rows[i];

                        var date = dataGridView1.Rows[searchOutput].Cells["date"].Value;
                        var error = dataGridView1.Rows[searchOutput].Cells["error"].Value;
                        var sourceError = dataGridView1.Rows[searchOutput].Cells["sourceError"].Value;
                        var stackTrace = dataGridView1.Rows[searchOutput].Cells["stackTrace"].Value;

                        dataGridView1.Rows[searchOutput].Cells["date"].Value = row.Cells["date"].Value;
                        dataGridView1.Rows[searchOutput].Cells["error"].Value = row.Cells["error"].Value;
                        dataGridView1.Rows[searchOutput].Cells["sourceError"].Value = row.Cells["sourceError"].Value;
                        dataGridView1.Rows[searchOutput].Cells["stackTrace"].Value = row.Cells["stackTrace"].Value;

                        row.Cells["date"].Value = date;
                        row.Cells["error"].Value = error;
                        row.Cells["sourceError"].Value = sourceError;
                        row.Cells["stackTrace"].Value = stackTrace;

                        var papaparsedData = completeErrors[searchOutput];
                        completeErrors[searchOutput] = completeErrors[i];
                        completeErrors[i] = papaparsedData;

                        searchOutput++;
                    }
                    else if (LongestCommonSubsequenceExtensions.LongestCommonSubsequence(query, errorModels[i].sourceError, true).Item2 > 0.001)
                    {
                        DataGridViewRow row = dataGridView1.Rows[i];

                        var date = dataGridView1.Rows[searchOutput].Cells["date"].Value;
                        var error = dataGridView1.Rows[searchOutput].Cells["error"].Value;
                        var sourceError = dataGridView1.Rows[searchOutput].Cells["sourceError"].Value;
                        var stackTrace = dataGridView1.Rows[searchOutput].Cells["stackTrace"].Value;

                        dataGridView1.Rows[searchOutput].Cells["date"].Value = row.Cells["date"].Value;
                        dataGridView1.Rows[searchOutput].Cells["error"].Value = row.Cells["error"].Value;
                        dataGridView1.Rows[searchOutput].Cells["sourceError"].Value = row.Cells["sourceError"].Value;
                        dataGridView1.Rows[searchOutput].Cells["stackTrace"].Value = row.Cells["stackTrace"].Value;

                        row.Cells["date"].Value = date;
                        row.Cells["error"].Value = error;
                        row.Cells["sourceError"].Value = sourceError;
                        row.Cells["stackTrace"].Value = stackTrace;

                        var papaparsedData = completeErrors[searchOutput];
                        completeErrors[searchOutput] = completeErrors[i];
                        completeErrors[i] = papaparsedData;

                        searchOutput++;
                    }
                }
                if (radioButton1.Checked)
                {
                    if (query.Length <= 2)
                    {
                        query = $":{query}";
                    }
                    if (query.Length != 19 && query.Length < 19)
                    {
                        if (errorModels[i].date.Contains(query) && query.Length >= 2)
                        {
                            //stringBuilder.Append(errorModels[i].date + '\r' + '\n');
                            DataGridViewRow row = dataGridView1.Rows[i];

                            var date = dataGridView1.Rows[searchOutput].Cells["date"].Value;
                            var error = dataGridView1.Rows[searchOutput].Cells["error"].Value;
                            var sourceError = dataGridView1.Rows[searchOutput].Cells["sourceError"].Value;
                            var stackTrace = dataGridView1.Rows[searchOutput].Cells["stackTrace"].Value;

                            dataGridView1.Rows[searchOutput].Cells["date"].Value = row.Cells["date"].Value;
                            dataGridView1.Rows[searchOutput].Cells["error"].Value = row.Cells["error"].Value;
                            dataGridView1.Rows[searchOutput].Cells["sourceError"].Value = row.Cells["sourceError"].Value;
                            dataGridView1.Rows[searchOutput].Cells["stackTrace"].Value = row.Cells["stackTrace"].Value;

                            row.Cells["date"].Value = date;
                            row.Cells["error"].Value = error;
                            row.Cells["sourceError"].Value = sourceError;
                            row.Cells["stackTrace"].Value = stackTrace;

                            var papaparsedData = completeErrors[searchOutput];
                            completeErrors[searchOutput] = completeErrors[i];
                            completeErrors[i] = papaparsedData;

                            searchOutput++;
                        }
                    }
                    else if (errorModels[i].date.Contains(query) && errorModels[i].date.Length == query.Length)
                    {

                        //stringBuilder.Append(errorModels[i].date + '\r' + '\n');
                        DataGridViewRow row = dataGridView1.Rows[i];

                        var date = dataGridView1.Rows[searchOutput].Cells["date"].Value;
                        var error = dataGridView1.Rows[searchOutput].Cells["error"].Value;
                        var sourceError = dataGridView1.Rows[searchOutput].Cells["sourceError"].Value;
                        var stackTrace = dataGridView1.Rows[searchOutput].Cells["stackTrace"].Value;

                        dataGridView1.Rows[searchOutput].Cells["date"].Value = row.Cells["date"].Value;
                        dataGridView1.Rows[searchOutput].Cells["error"].Value = row.Cells["error"].Value;
                        dataGridView1.Rows[searchOutput].Cells["sourceError"].Value = row.Cells["sourceError"].Value;
                        dataGridView1.Rows[searchOutput].Cells["stackTrace"].Value = row.Cells["stackTrace"].Value;

                        row.Cells["date"].Value = date;
                        row.Cells["error"].Value = error;
                        row.Cells["sourceError"].Value = sourceError;
                        row.Cells["stackTrace"].Value = stackTrace;

                        var papaparsedData = completeErrors[searchOutput];
                        completeErrors[searchOutput] = completeErrors[i];
                        completeErrors[i] = papaparsedData;

                        searchOutput++;

                    }
                }

                


                dataGridView1.FirstDisplayedScrollingRowIndex = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ShowCellToolTips = false;

        }


        string fileDirectory;
        private void button1_Click(object sender, EventArgs e)
        {
            parsedData.Clear();
            errorModels.Clear();
            completeErrors.Clear();
            dataGridView1.DataSource = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();




            #region //Parser
            try
            {

                openFileDialog.Filter = "Log Files|*.log";
                openFileDialog.FilterIndex = 1;
                openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileDirectory = openFileDialog.FileName;
                    this.fileDirectory = fileDirectory;
                }

           
                StringBuilder exception = new StringBuilder();
                using (StreamReader sr = new StreamReader(this.@fileDirectory, Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (Regex.Match(line, @"^\d\d\d\d[-]\d\d[-]\d\d").Success)
                        {
                            if (exception.Length != 0)
                            {
                                parsedData.Add(exception.ToString());
                            }
                            exception.Clear();
                        }
                        exception.Append(line + "\n");

                    }
                    if (exception.Length != 0)
                    {
                        parsedData.Add(exception.ToString());
                    }
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("\nЕсли вы хотите работать с лог файломи то выберите файл с котором хотите работать.", "Вы не выбрали файл!");
            }
            
            #endregion

            Filter(parsedData);


        }
        private List<ErrorModel> Filter(List<string> sortData)
        {
            // List<ErrorModel> errorModels = new List<ErrorModel>();
            foreach (var sCollection in sortData)
            {
                ErrorModel errorModel = new ErrorModel();
                CompleteError completeError = new CompleteError();
                completeError.allError = sCollection;
                //Date___________________________________________________________________________________________________
                string date = sCollection.Substring(0, sCollection.IndexOf(','));
                errorModel.date = date;
                completeError.date = date;
                
                //Error__________________________________________________________________________________________________
                string[] error = sCollection.Split('\n');
                for (int i = 1; i < error.Length;)
                {
                    string[] trueError = error[i].Split(':');

                    errorModel.error = trueError[0];
                    completeError.error = trueError[0].ToString();
                    break;
                }

                //SourceError____________________________________________________________________________________________
                StringBuilder sourceError = new StringBuilder();
                string[] splitArray = sCollection.Split('\n');
                for (int i = 1; i < splitArray.Length; i++)
                {
                    if (splitArray[i].Contains("Server stack trace:"))//отделить ошибку от пути ошибки
                    {
                        break;
                    }
                    if (splitArray[i]==splitArray[1])
                    {
                        StringBuilder Otdelenie = new StringBuilder();
                        string[] a = splitArray[i].Split(' ');

                        for (int j = 1;j<a.Length;j++) 
                        {
                            Otdelenie.Append(a[j]+" ");
                        }
                        sourceError.Append(Otdelenie);

                    }
                    if (splitArray[i] != splitArray[1])
                    {
                        sourceError.Append(splitArray[i] + "\n");
                    }
                        
                }
                
                errorModel.sourceError = sourceError.ToString();

                //ServerStackTrace________________________________________________________________________________________
                string serverStackTrace = sCollection.Substring(sCollection.IndexOf("Server stack trace:"));
                errorModel.stackTrace = serverStackTrace;


                errorModels.Add(errorModel);
                completeErrors.Add(completeError);

            }

            dataGridView1.DataSource = errorModels;

            return errorModels;
        }
        bool forReverse = false;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 1)
            {
                completeErrors.Sort((x, y) => String.CompareOrdinal(x.error, y.error));
                errorModels.Sort((x, y) => String.CompareOrdinal(x.error, y.error));
                
                if (forReverse == false)
                {
                    forReverse = true;
                }
                else if (forReverse == true)
                {
                    errorModels.Reverse();
                    completeErrors.Reverse();
                    forReverse = false;
                }
                dataGridView1.Refresh();
            }
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
            {
                completeErrors.Sort((x, y) => String.CompareOrdinal(x.date, y.date));
                errorModels.Sort((x, y) => String.CompareOrdinal(x.date, y.date));
                
                if (forReverse==false)
                {
                    forReverse = true;
                }
                else if (forReverse == true)
                {
                    errorModels.Reverse();
                    completeErrors.Reverse();
                    forReverse = false;
                }

                dataGridView1.Refresh();
            }
            
        }



        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               button2_Click(sender, e);
            }
        }

        DataGridViewCellEventArgs ee;
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1_CellDoubleClick(sender, ee);
            }



        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < parsedData.Count && e.RowIndex > -1 && e.ColumnIndex > -1 && e.ColumnIndex < 5)
            {
                Form2 form2 = new Form2(e);
                form2.ShowDialog();
            }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            ee = e;
        }
    }

    internal class index
    {
    }
}
