using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ARMO_test_task
{
    
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            treeView1.AfterExpand += treeView1_AfterExpand;
            treeView1.AfterSelect += treeView1_AfterSelect;
        }

        private void Count()
        {
            int x = 0;
            int x1 = 0;
            int y = 0;
            x = PC + PC1;
            x1 = FC + FC1;
            y = x + x1;
            label3.Text = $"Общее количество папок в текущей директории: {x}";
            label2.Text = $"Общее количество файлов в текущей директории: {x1}";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            treeView1.Nodes.Clear();         
            TreeNode tr = new TreeNode { Text = textBox1.Text };
            GetFolders(textBox1.Text, tr);
            treeView1.Nodes.Add(tr);
            Count();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr =  fbd.ShowDialog();
            if(dr == DialogResult.OK)
            {
                
                TreeNode tr = new TreeNode { Text = fbd.SelectedPath};
                GetFolders(fbd.SelectedPath,tr);
                treeView1.Nodes.Add(tr);
                Count();
            }
        }

        int PC = 0;
        int FC = 0;
        private void FillTree(string path, TreeNode NewNode)
        {
            try
            {
                PC = 0;
                string[] dir = Directory.GetDirectories(path);
                for (int i = 0; i < dir.Length; i++)
                {
                    PC++;
                    TreeNode tr = new TreeNode { Text = dir[i] };
                    tr.Text = dir[i].Remove(0, dir[i].LastIndexOf("\\") + 1);
                    NewNode.Nodes.Add(tr);
                }
                FC = 0;
                string[] dirF = Directory.GetFiles(path);
                for (int i = 0; i < dirF.Length; i++)
                {
                    FC++;
                    TreeNode trF = new TreeNode { Text = dirF[i] };
                    trF.Text = dirF[i].Remove(0, dir[i].LastIndexOf("\\") + 1);
                    NewNode.Nodes.Add(trF);
                }
            }
            catch (Exception ex) { }
           
        }
        int PC1 = 0;
        int FC1 = 0;
        private void GetFolders(string path, TreeNode Anode)
        {
            try
            {
                PC1 = 0;
                string[] dir = Directory.GetDirectories(path);
                for (int i = 0; i < dir.Length; i++)
                {
                    PC1++;
                    TreeNode tr = new TreeNode { Text = dir[i] };
                    tr.Text = dir[i].Remove(0, dir[i].LastIndexOf("\\") + 1);
                    FillTree(dir[i], tr);
                    Anode.Nodes.Add(tr);
                }
                FC1 = 0;
                string[] dirF = Directory.GetFiles(path);
                for (int i = 0; i < dirF.Length; i++)
                {
                    FC1++;
                    TreeNode trF = new TreeNode { Text = dirF[i] };
                    trF.Text = dirF[i].Remove(0, dirF[i].LastIndexOf("\\") + 1);
                    FillTree(dirF[i], trF);
                    Anode.Nodes.Add(trF);
                }
                
            }
            catch (Exception ex) { }
           
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            textBox1.Text = e.Node.FullPath;
           
        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            textBox1.Text = e.Node.FullPath;
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Cancel();
            treeView1.Nodes.Clear();
            textBox1.Text = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr = fbd.ShowDialog();
            if (dr == DialogResult.OK)
            {

                TreeNode tr = new TreeNode { Text = fbd.SelectedPath };
                GetFolders(fbd.SelectedPath, tr);
                treeView1.Nodes.Add(tr);
                Count();
                
            }
        }
        List<TreeNode> SearchedNodes = new List<TreeNode>();
        string LastSearch;

        private void Find(string stext, TreeNode sNode)
        {
            while(sNode != null)
            {
                if (sNode.Text.Contains(stext))
                {
                    SearchedNodes.Add(sNode);
                }

                if (sNode.Nodes.Count != 0)
                {
                    Find(stext, sNode.Nodes[0]);
                }
                sNode = sNode.NextNode;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cancel();
            
        }

        private void Cancel()
        {
            try
            {
                label4.Text = $"Количество найденных файлов: {0}";
                textBox2.Text = "";
                if (SearchedNodes.Count > 0)
                {
                    for (int i = 0; i < SearchedNodes.Count; i++)
                    {
                        TreeNode tr = SearchedNodes[i];
                        treeView1.SelectedNode = tr;
                        treeView1.SelectedNode.Collapse();
                        treeView1.SelectedNode.BackColor = treeView1.BackColor;
                        treeView1.Select();

                    }
                }
                button3.Visible = true;
                button2.Visible = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text.Length > 0)
                {
                    if (LastSearch != textBox2.Text)
                    {
                        
                        SearchedNodes.Clear();
                        LastSearch = textBox2.Text;
                        Find(textBox2.Text, treeView1.Nodes[0]);
                    }
                }
                else
                {
                    MessageBox.Show("Пустое значение");
                    button2.Visible = false;
                    button3.Visible = true;
                }
                int i = 0;
                if (SearchedNodes.Count > 0)
                {
                    for (; i < SearchedNodes.Count; i++)
                    {
                        TreeNode tr = SearchedNodes[i];
                        treeView1.SelectedNode = tr;
                        treeView1.SelectedNode.Expand();
                        treeView1.SelectedNode.BackColor = Color.Red;
                        treeView1.Select();
                    }
                    label4.Text = $"Количество найденных файлов: {i}";
                    button2.Visible = true;
                    button3.Visible = false;
                }
            }
            catch (Exception ex) { }
           
        }
    }
}
