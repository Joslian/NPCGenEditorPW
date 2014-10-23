using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NPCGenToXml
{
    public partial class FormMain : Form
    {
        public ObservableCollection<AREA> m_aAreas;
        public ObservableCollection<RESAREA> m_aResAreas;
        public ObservableCollection<DYNOBJ> m_aDynObjs;
        public ObservableCollection<CONTROLLER> m_aControllers;
        public ObservableCollection<FLYAREA> m_aFlyAreas;

        uint version = 0;
        int iNumAIGen = 0;
        int iNumResArea = 0;
        int iNumDynObj = 0;
        int iNumNPCCtrl = 0;
        int iNumFlyArea = 0;
        int iNumMineralCube = 0;
        int iNumMineralSphere = 0;
        int export_time = 0;
        short export_vss_name = 0;
        short export_computer_name =0;
        byte[] unk;
        public bool Fileloaded = false;

        public FormMain()
        {
            InitializeComponent();

            propertyGrid_aAreas.HelpVisible = false;
            propertyGrid_aResAreas.HelpVisible = false;
            propertyGrid_aDynObjs.HelpVisible = false;
            propertyGrid_aControllers.HelpVisible = false;
            propertyGrid_aFlyAreas.HelpVisible = false;

            propertyGrid_aAreas.PropertySort = PropertySort.NoSort;
            propertyGrid_aResAreas.PropertySort = PropertySort.NoSort;
            propertyGrid_aDynObjs.PropertySort = PropertySort.NoSort;
            propertyGrid_aControllers.PropertySort = PropertySort.NoSort;
            propertyGrid_aFlyAreas.PropertySort = PropertySort.NoSort;
        }

        private void Button_FileRead_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "NPCGen File|npcgen.data|Data Files|*.data|All Files|*.*";
            if (openFile.ShowDialog() == DialogResult.OK && openFile.FileName != null)
            {
                using (BinaryReader br = new BinaryReader(File.OpenRead(openFile.FileName)))
                {
                    version = br.ReadUInt32();
                    iNumAIGen = br.ReadInt32();
                    iNumResArea = br.ReadInt32();

                    if (version >= 6)
                        iNumDynObj = br.ReadInt32();
                    if (version >= 7)
                        iNumNPCCtrl = br.ReadInt32();
                    if (version >= 16)
                        iNumFlyArea = br.ReadInt32();
                    if (version == 16) {
                        iNumMineralCube = br.ReadInt32();
                        iNumMineralSphere = br.ReadInt32();
                    }
                    if (version > 20 && version < 23) {
                        export_time = br.ReadInt32();
                        export_vss_name = br.ReadInt16();
                        export_computer_name = br.ReadInt16();
                    }
                    if (version == 23)
                        unk = br.ReadBytes(272);

                    m_aAreas = new ObservableCollection<AREA>();
                    for (int i = 0; i < iNumAIGen; i++) {
                        m_aAreas.Add(new AREA(br, version));
                        listBox_aAreas.Items.Add(m_aAreas[i]);
                    }

                    m_aResAreas = new ObservableCollection<RESAREA>();
                    for (int i = 0; i < iNumResArea; i++) {
                        m_aResAreas.Add(new RESAREA(br, version));
                        listBox_aResAreas.Items.Add(m_aResAreas[i]);
                    }

                    m_aDynObjs = new ObservableCollection<DYNOBJ>();
                    for (int i = 0; i < iNumDynObj; i++) {
                        m_aDynObjs.Add(new DYNOBJ(br, version));
                        listBox_aDynObjs.Items.Add(m_aDynObjs[i]);
                    }

                    m_aControllers = new ObservableCollection<CONTROLLER>();
                    for (int i = 0; i < iNumNPCCtrl; i++) {
                        m_aControllers.Add(new CONTROLLER(br, version));
                        listBox_aControllers.Items.Add(m_aControllers[i]);
                    }

                    m_aFlyAreas = new ObservableCollection<FLYAREA>();
                    for (int i = 0; i < iNumFlyArea; i++) {
                        m_aFlyAreas.Add(new FLYAREA(br));
                        listBox_aFlyAreas.Items.Add(m_aFlyAreas[i]);
                    }
                }
            }
            Fileloaded = true;
        }

        private void Btn_FileSave_Click(object sender, EventArgs e)
        {
            if (!Fileloaded) return;
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "NPCGen File|npcgen.data|Data Files|*.data|All Files|*.*";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                using (BinaryWriter bw = new BinaryWriter(new FileStream(saveFile.FileName, FileMode.Create, FileAccess.Write)))
                {
                    bw.Write(version);
                    bw.Write(iNumAIGen);
                    bw.Write(iNumResArea);

                    if (version >= 6)
                        bw.Write(iNumDynObj);
                    if (version >= 7)
                        bw.Write(iNumNPCCtrl);
                    if (version >= 16)
                        bw.Write(iNumFlyArea);
                    if (version == 16) {
                        bw.Write(iNumMineralCube);
                        bw.Write(iNumMineralSphere);
                    }
                    if (version > 20 && version < 23) {
                        bw.Write(export_time);
                        bw.Write(export_vss_name);
                        bw.Write(export_computer_name);
                    }
                    if (version == 23)
                        bw.Write(unk);

                    for (int i = 0; i < iNumAIGen; i++)
                        m_aAreas[i].Write(bw, version);
                    for (int i = 0; i < iNumResArea; i++)
                        m_aResAreas[i].Write(bw, version);
                    for (int i = 0; i < iNumDynObj; i++)
                        m_aDynObjs[i].Write(bw, version);
                    for (int i = 0; i < iNumNPCCtrl; i++)
                        m_aControllers[i].Write(bw, version);
                    for (int i = 0; i < iNumFlyArea; i++)
                        m_aFlyAreas[i].Write(bw);
                }
            }
            MessageBox.Show("Сохранено");
        }

        private void listBox_aAreas_SelectedIndexChanged(object sender, EventArgs e) {
            propertyGrid_aAreas.SelectedObject = m_aAreas[listBox_aAreas.SelectedIndex];
        }

        private void listBox_aResAreas_SelectedIndexChanged(object sender, EventArgs e) {
            propertyGrid_aResAreas.SelectedObject = m_aResAreas[listBox_aResAreas.SelectedIndex];
        }

        private void listBox_aDynObjs_SelectedIndexChanged(object sender, EventArgs e) {
            propertyGrid_aDynObjs.SelectedObject = m_aDynObjs[listBox_aDynObjs.SelectedIndex];
        }

        private void listBox_aControllers_SelectedIndexChanged(object sender, EventArgs e) {
            propertyGrid_aControllers.SelectedObject = m_aControllers[listBox_aControllers.SelectedIndex];
        }

        private void listBox_aFlyAreas_SelectedIndexChanged(object sender, EventArgs e) {
            propertyGrid_aFlyAreas.SelectedObject = m_aFlyAreas[listBox_aFlyAreas.SelectedIndex];
        }
    }
}
