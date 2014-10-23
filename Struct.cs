using System;
using System.IO;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace NPCGenToXml
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class AREA
    {
        public override string ToString()
        {
            return m_aNPCGens.Count > 0 ? string.Format("{0}: {1}", "AREA", m_aNPCGens[0].dwID) : string.Format("{0}: {1}", "AREA", 0);
        }
        public int iType { get; set; }
        public int iNumGen { get; set; }
        public float[] vPos { get; set; } // 3
        public float[] vDir { get; set; } // 3
        public float[] vExts { get; set; } // 3
        public int iFirstGen;
        public int iNPCType { get; set; }
        public int iGroupType { get; set; }
        public bool bAutoRevive { get; set; }
        public int idCtrl { get; set; }
        public int iLifeTime { get; set; }
        public int iMaxNum { get; set; }

        public bool bInitGen { get; set; }
        public bool bValidOnce { get; set; }
        public int dwGenID { get; set; }
        public int dwExportID { get; set; }
        public int iAttachNum { get; set; }
        public int idBufRegion { get; set; }
        public ObservableCollection<NPCGEN> m_aNPCGens { get; set; }
        public ObservableCollection<int> Attach { get; set; }

        public AREA(BinaryReader br, uint version)
        {
            iType = br.ReadInt32();
            iNumGen = br.ReadInt32();
            vPos = new float[3];
            for (int i = 0; i < 3; i++)
                vPos[i] = br.ReadSingle();
            vDir = new float[3];
            for (int i = 0; i < 3; i++)
                vDir[i] = br.ReadSingle();
            vExts = new float[3];
            for (int i = 0; i < 3; i++)
                vExts[i] = br.ReadSingle();
            iNPCType = br.ReadInt32();
            iGroupType = br.ReadInt32();
            bInitGen = br.ReadBoolean();
            bAutoRevive = br.ReadBoolean();
            bValidOnce = br.ReadBoolean();
            dwGenID = br.ReadInt32();
            if (version > 6) {
                idCtrl = br.ReadInt32();
                iLifeTime = br.ReadInt32();
                iMaxNum = br.ReadInt32();
            }
            if (version > 11) {
                dwExportID = br.ReadInt32();
                iAttachNum = br.ReadInt32();
            }
            if (version > 12)
                idBufRegion = br.ReadInt32();
            m_aNPCGens = new ObservableCollection<NPCGEN>();
            for (int i = 0; i < iNumGen; i++)
                m_aNPCGens.Add(new NPCGEN(br, version));
            Attach = new ObservableCollection<int>();
            for (int i = 0; i < iAttachNum; i++)
                Attach.Add(br.ReadInt32());
        }

        public void Write(BinaryWriter bw, uint version) {
            bw.Write(iType);
            bw.Write(iNumGen);
            for (int i = 0; i < 3; i++)
                bw.Write(vPos[i]);
            for (int i = 0; i < 3; i++)
                bw.Write(vDir[i]);
            for (int i = 0; i < 3; i++)
                bw.Write(vExts[i]);
            bw.Write(iNPCType);
            bw.Write(iGroupType);
            bw.Write(bInitGen);
            bw.Write(bAutoRevive);
            bw.Write(bValidOnce);
            bw.Write(dwGenID);
            if (version > 6) {
                bw.Write(idCtrl);
                bw.Write(iLifeTime);
                bw.Write(iMaxNum);
            }
            if (version > 11) {
                bw.Write(dwExportID);
                bw.Write(iAttachNum);
            }
            if (version > 12)
                bw.Write(idBufRegion);
            for (int i = 0; i < iNumGen; i++)
                m_aNPCGens[i].Write(bw, version);
            for (int i = 0; i < iAttachNum; i++)
                bw.Write(Attach[i]);
        }

        public AREA() {
            vPos = new float[3];
            for (int i = 0; i < 3; i++)
                vPos[i] = new float();
            vDir = new float[3];
            for (int i = 0; i < 3; i++)
                vDir[i] = new float();
            vExts = new float[3];
            for (int i = 0; i < 3; i++)
                vExts[i] = new float();
            m_aNPCGens = new ObservableCollection<NPCGEN>();
            Attach = new ObservableCollection<int>();
        }
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class NPCGEN
    {
        public override string ToString() {
            return string.Format("{0}", "NPCGEN");
        }
        public int iArea { get; set; }
        public uint dwID { get; set; }
        public uint dwNum { get; set; }
        public int iRefresh { get; set; }
        public uint dwDiedTimes { get; set; }
        public uint dwAggressive { get; set; }
        public float fOffsetWater { get; set; }
        public float fOffsetTrn { get; set; }
        public uint dwFaction { get; set; }
        public uint dwFacHelper { get; set; }
        public uint dwFacAccept { get; set; }
        public bool bNeedHelp { get; set; }
        public bool bDefFaction { get; set; }
        public bool bDefFacHelper { get; set; }
        public bool bDefFacAccept { get; set; }
        public int iPathID { get; set; }
        public int iLoopType { get; set; }
        public int iSpeedFlag { get; set; }
        public int iDeadTime { get; set; }
        public int iRefreshLower { get; set; }

        public NPCGEN(BinaryReader br, uint version)
        {
            if (version == 11)
                iArea = br.ReadInt32();
            dwID = br.ReadUInt32();
            dwNum = br.ReadUInt32();
            iRefresh = br.ReadInt32();
            dwDiedTimes = br.ReadUInt32();
            dwAggressive = br.ReadUInt32();
            fOffsetWater = br.ReadSingle();
            fOffsetTrn = br.ReadSingle();
            dwFaction = br.ReadUInt32();
            dwFacHelper = br.ReadUInt32();
            dwFacAccept = br.ReadUInt32();
            bNeedHelp = br.ReadBoolean();
            bDefFaction = br.ReadBoolean();
            bDefFacHelper = br.ReadBoolean();
            bDefFacAccept = br.ReadBoolean();
            iPathID = br.ReadInt32();
            iLoopType = br.ReadInt32();
            iSpeedFlag = br.ReadInt32();
            iDeadTime = br.ReadInt32();
        }

        public void Write(BinaryWriter bw, uint version) {
            if (version == 11)
                bw.Write(iArea);
            bw.Write(dwID);
            bw.Write(dwNum);
            bw.Write(iRefresh);
            bw.Write(dwDiedTimes);
            bw.Write(dwAggressive);
            bw.Write(fOffsetWater);
            bw.Write(fOffsetTrn);
            bw.Write(dwFaction);
            bw.Write(dwFacHelper);
            bw.Write(dwFacAccept);
            bw.Write(bNeedHelp);
            bw.Write(bDefFaction);
            bw.Write(bDefFacHelper);
            bw.Write(bDefFacAccept);
            bw.Write(iPathID);
            bw.Write(iLoopType);
            bw.Write(iSpeedFlag);
            bw.Write(iDeadTime);
        }

        public NPCGEN() {

        }
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class RESAREA
    {
        public override string ToString() {
            return string.Format("{0}", "RESAREA");
        }
        public float[] vPos { get; set; } // 3
        public float fExtX { get; set; }
        public float fExtZ { get; set; }
        public int iFirstRes;
        public int iResNum { get; set; }
        public bool bAutoRevive { get; set; }
        public int idCtrl { get; set; }
        public int iMaxNum { get; set; }
        public byte[] dir { get; set; } // 2
        public byte rad { get; set; }

        public bool bInitGen { get; set; }
        public bool bValidOnce { get; set; }
        public int dwGenID { get; set; }
        public int dwExportID { get; set; }
        public int iAttachNum { get; set; }
        public int iType { get; set; }
        public float fExtY { get; set; }
        public float fRadius { get; set; }
        public ObservableCollection<RES> m_aRes { get; set; }
        public ObservableCollection<int> Attach { get; set; }

        public RESAREA(BinaryReader br, uint version) {
            vPos = new float[3];
            for (int i = 0; i < 3; i++)
                vPos[i] = br.ReadSingle();
            fExtX = br.ReadSingle();
            fExtZ = br.ReadSingle();
            iResNum = br.ReadInt32();
            bInitGen = br.ReadBoolean();
            bAutoRevive = br.ReadBoolean();
            bValidOnce = br.ReadBoolean();
            dwGenID = br.ReadInt32();
            if (version > 5) {
                dir = br.ReadBytes(2);
                rad = br.ReadByte();
            }
            if (version > 6) {
                idCtrl = br.ReadInt32();
                iMaxNum = br.ReadInt32();
            }
            if (version > 11) {
                dwExportID = br.ReadInt32();
                iAttachNum = br.ReadInt32();
            }
            if (version > 16) {
                iType = br.ReadInt32();
                fExtY = br.ReadSingle();
                fRadius = br.ReadSingle();
            }
            m_aRes = new ObservableCollection<RES>();
            for (int i = 0; i < iResNum; i++)
                m_aRes.Add(new RES(br));
            Attach = new ObservableCollection<int>();
            for (int i = 0; i < iAttachNum; i++)
                Attach.Add(br.ReadInt32());
        }

        public void Write(BinaryWriter bw, uint version) {
            for (int i = 0; i < 3; i++)
                bw.Write(vPos[i]);
            bw.Write(fExtX);
            bw.Write(fExtZ);
            bw.Write(iResNum);
            bw.Write(bInitGen);
            bw.Write(bAutoRevive);
            bw.Write(bValidOnce);
            bw.Write(dwGenID);
            if (version > 5) {
                bw.Write(dir);
                bw.Write(rad);
            }
            if (version > 6) {
                bw.Write(idCtrl);
                bw.Write(iMaxNum);
            }
            if (version > 11) {
                bw.Write(dwExportID);
                bw.Write(iAttachNum);
            }
            if (version > 16) {
                bw.Write(iType);
                bw.Write(fExtY);
                bw.Write(fRadius);
            }
            for (int i = 0; i < iResNum; i++)
                m_aRes[i].Write(bw);
            for (int i = 0; i < iAttachNum; i++)
                bw.Write(Attach[i]);
        }

        public RESAREA() {
            vPos = new float[3];
            for (int i = 0; i < 3; i++)
                vPos[i] = new float();
            m_aRes = new ObservableCollection<RES>();
            Attach = new ObservableCollection<int>();
        }
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class RES
    {
        public override string ToString() {
            return string.Format("{0}", "RES");
        }
        public int iResType { get; set; }
        public int idTemplate { get; set; }
        public uint dwRefreshTime { get; set; }
        public uint dwNumber { get; set; }
        public float fHeiOff { get; set; }

        public RES(BinaryReader br) {
            iResType = br.ReadInt32();
            idTemplate = br.ReadInt32();
            dwRefreshTime = br.ReadUInt32();
            dwNumber = br.ReadUInt32();
            fHeiOff = br.ReadSingle();
        }

        public void Write(BinaryWriter bw) {
            bw.Write(iResType);
            bw.Write(idTemplate);
            bw.Write(dwRefreshTime);
            bw.Write(dwNumber);
            bw.Write(fHeiOff);
        }

        public RES() {

        }
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class DYNOBJ
    {
        public override string ToString() {
            return string.Format("{0}", "DYNOBJ");
        }
        public uint dwDynObjID { get; set; }
        public float[] vPos { get; set; } // 3
        public byte[] dir { get; set; } // 2
        public byte rad { get; set; }
        public uint idCtrl { get; set; }
        public byte scale { get; set; }

        public bool bBroadcast { get; set; }

        public DYNOBJ(BinaryReader br, uint version) {
            dwDynObjID = br.ReadUInt32();
            vPos = new float[3];
            for (int i = 0; i < 3; i++)
                vPos[i] = br.ReadSingle();
            dir = br.ReadBytes(2);
            rad = br.ReadByte();
            if (version >= 9)
                scale = br.ReadByte();
            if (version >= 10)
                idCtrl = br.ReadUInt32();
            if (version >= 14)
                bBroadcast = br.ReadBoolean();
        }

        public void Write(BinaryWriter bw, uint version) {
            bw.Write(dwDynObjID);
            for (int i = 0; i < 3; i++)
                bw.Write(vPos[i]);
            bw.Write(dir);
            bw.Write(rad);
            if (version >= 9)
                bw.Write(scale);
            if (version >= 10)
                bw.Write(idCtrl);
            if (version >= 14)
                bw.Write(bBroadcast);
        }

        public DYNOBJ() {
            vPos = new float[3];
            for (int i = 0; i < 3; i++)
                vPos[i] = new float();
        }
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class CONTROLLER
    {
        public override string ToString() {
            return string.Format("{1} — {3}", "CONTROLLER", id, iControllerID, szName);
        }
        public uint id { get; set; }
        public int iControllerID { get; set; }
        public string szName { get; set; } // 128
        public bool bActived { get; set; }
        public int iWaitTime { get; set; }
        public int iStopTime { get; set; }
        public bool bActiveTimeInvalid { get; set; }
        public bool bStopTimeInvalid { get; set; }
        public int iActiveTimeRange { get; set; }
        public NPCCTRLTIME ActiveTime { get; set; }
        public NPCCTRLTIME StopTime { get; set; }

        public bool bRepeatActived { get; set; }
        public long mZoneMask { get; set; }

        public CONTROLLER(BinaryReader br, uint version) {
            id = br.ReadUInt32();
            iControllerID = br.ReadInt32();
            szName = br.ReadTaskChar(64);
            bActived = br.ReadBoolean();
            iWaitTime = br.ReadInt32();
            iStopTime = br.ReadInt32();
            bActiveTimeInvalid = br.ReadBoolean();
            bStopTimeInvalid = br.ReadBoolean();
            ActiveTime = new NPCCTRLTIME(br);
            StopTime = new NPCCTRLTIME(br);
            if (version >= 8)
                iActiveTimeRange = br.ReadInt32();
            if (version > 11)
                bRepeatActived = br.ReadBoolean();
            if (version >= 15)
                mZoneMask = br.ReadInt64();
        }

        public void Write(BinaryWriter bw, uint version) {
            bw.Write(id);
            bw.Write(iControllerID);
            bw.WriteTaskChar(szName, 64);
            bw.Write(bActived);
            bw.Write(iWaitTime);
            bw.Write(iStopTime);
            bw.Write(bActiveTimeInvalid);
            bw.Write(bStopTimeInvalid);
            ActiveTime.Write(bw);
            StopTime.Write(bw);
            if (version >= 8)
                bw.Write(iActiveTimeRange);
            if (version > 11)
                bw.Write(bRepeatActived);
            if (version >= 15)
                bw.Write(mZoneMask);
        }

        public CONTROLLER() {
            szName = Encoding.Unicode.GetString(new byte[0]);
            ActiveTime = new NPCCTRLTIME();
            StopTime = new NPCCTRLTIME();
        }
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class NPCCTRLTIME
    {
        public override string ToString() {
            return string.Format("{0}", "NPCCTRLTIME");
        }
        public int iYear { get; set; }
        public int iMouth { get; set; }
        public int iWeek { get; set; }
        public int iDay { get; set; }
        public int iHours { get; set; }
        public int iMinutes { get; set; }

        public NPCCTRLTIME(BinaryReader br) {
            iYear = br.ReadInt32();
            iMouth = br.ReadInt32();
            iWeek = br.ReadInt32();
            iDay = br.ReadInt32();
            iHours = br.ReadInt32();
            iMinutes = br.ReadInt32();
        }

        public void Write(BinaryWriter bw) {
            bw.Write(iYear);
            bw.Write(iMouth);
            bw.Write(iWeek);
            bw.Write(iDay);
            bw.Write(iHours);
            bw.Write(iMinutes);
        }

        public NPCCTRLTIME() {
        }
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class FLYAREA
    {
        public override string ToString() {
            return string.Format("{0}", "FLYAREA");
        }
        public int iPointNum { get; set; }
        public ObservableCollection<float> pPoints1 { get; set; }
        public ObservableCollection<float> pPoints2 { get; set; }
        public float fHeight { get; set; }
        public int iRequireLevel { get; set; }

        public FLYAREA(BinaryReader br) {
            iPointNum = br.ReadInt32();
            pPoints1 = new ObservableCollection<float>();
            pPoints2 = new ObservableCollection<float>();
            for (int i = 0; i < iPointNum; i++) {
                pPoints1.Add(br.ReadSingle());
                pPoints2.Add(br.ReadSingle());
            }
            fHeight = br.ReadSingle();
            iRequireLevel = br.ReadInt32();
        }

        public void Write(BinaryWriter bw) {
            bw.Write(iPointNum);
            for (int i = 0; i < iPointNum; i++) {
                bw.Write(pPoints1[i]);
                bw.Write(pPoints2[i]);
            }
            bw.Write(fHeight);
            bw.Write(iRequireLevel);
        }

        public FLYAREA() {
            pPoints1 = new ObservableCollection<float>();
            pPoints2 = new ObservableCollection<float>();
        }
    }
}