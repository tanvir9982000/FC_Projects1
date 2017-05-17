using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slb.Ocean.Core;
using Slb.Ocean.Petrel;
using Slb.Ocean.Petrel.DomainObject;
//using Slb.Ocean.Petrel.PetrelUnitSystem;
using Slb.Ocean.Basics;
using Slb.Ocean.Petrel.UI;
using Slb.Ocean.Petrel.Workflow;

using System.Drawing;
using System.Windows.Forms;

using Slb.Ocean.Petrel.DomainObject.Well;


using Slb.Ocean.Data;
using Slb.Ocean.Units;

namespace FracScope
{
    class FracScopeModel : DescribedArgumentsByReflection
    {
        /*******************Variables of the Class******************/

        //Project Variables
        private Project PS_proj;
        private WellRoot PS_WlRoot;
        private Borehole PS_bh;

        //Well Log Variables 
        private WellLog PS_VolumeOfShale;
        private WellLog PS_DensityPorosity;
        private WellLog PS_KerogenContent;
        private WellLog PS_TotalOrganicCarbon;
        private WellLog PS_ClayPorosity;
        private WellLog PS_FracturePorosity;
        private WellLog PS_OrganicPorosity;
        private WellLog PS_TotalPorosity;

        public WellLog TotalPorosity
        {
            get { return PS_TotalPorosity; }
            set { PS_TotalPorosity = value; }
        }

        private WellLog PS_SandPorosity;
        public WellLog SandPorosity
        {
            get { return PS_SandPorosity; }
            set { PS_SandPorosity = value; }
        }

        private WellLog PS_InterParticlePorosity;
        private WellLog PS_YoungModulas;
        private WellLog PS_PoissonRatio;

        private WellLog PS_C33WellLog;
        private WellLog PS_C44WellLog;


        private WellLog PS_C66WellLog;


        private WellLog PS_C13WellLog;
        private WellLog PS_C12WellLog;

        private WellLog PS_C11WellLog;



        private WellLog PS_YoungModulasHorizontal;


        private WellLog PS_YoungModulasVertical;

        public WellLog YoungModulasVertical
        {
            get { return PS_YoungModulasVertical; }
            set { PS_YoungModulasVertical = value; }
        }

        private WellLog PS_PoissonRatioHorizontal;

        public WellLog PoissonRatioHorizontal
        {
            get { return PS_PoissonRatioHorizontal; }
            set { PS_PoissonRatioHorizontal = value; }
        }
        private WellLog PS_PoissonRatioVertical;

        public WellLog PoissonRatioVertical
        {
            get { return PS_PoissonRatioVertical; }
            set { PS_PoissonRatioVertical = value; }
        }

        private WellLog PS_MinHorStress;

        public WellLog MinHorStress
        {
            get { return PS_MinHorStress; }
            set { PS_MinHorStress = value; }
        }


        private WellLog PS_BrittlenessIndex;
        private WellLog PS_Epsilon;
        private WellLog PS_Gamma;
        private WellLog PS_Delta;
        private WellLog PS_AzimuthalAnisotropy;

        public WellLog AzimuthalAnisotropy
        {
            get { return PS_AzimuthalAnisotropy; }
            set { PS_AzimuthalAnisotropy = value; }
        }

        private WellLog PS_VerticalStress;
        public WellLog VerticalStress
        {
            get { return PS_VerticalStress; }
            set { PS_VerticalStress = value; }
        }

        //private const int 

        //Well Log Versions
        String PS_VSH = "PS_VSH";          //These names Corresponds to the Well Logs declared above;
        String PS_DP = "PS_DP";
        String PS_KC = "PS_KC";
        String PS_TOC = "PS_TOC";
        String PS_CP = "PS_CP";
        String PS_FP = "PS_FP";
        String PS_OP = "PS_OP";
        String PS_TP = "PS_TP";
        String PS_SP = "PS_SP";

        String PS_IPP = "PS_IPP";
        String PS_YM = "PS_YM";
        String PS_PR = "PS_PR";



        String PS_C33 = "PS_33";


        String PS_C44 = "PS_C44";

        public String C44
        {
            get { return PS_C44; }
            set { PS_C44 = value; }
        }


        String PS_C66 = "PS_C66";

        public String C66
        {
            get { return PS_C66; }
            set { PS_C66 = value; }
        }
        String PS_C13 = "PS_C13";

        String PS_C12 = "PS_C12";

        public String C13
        {
            get { return PS_C13; }
            set { PS_C13 = value; }
        }
        String PS_C11 = "PS_C11";

        public String C11
        {
            get { return PS_C11; }
            set { PS_C11 = value; }
        }

        String PS_YMH = "PS_YMH";

        public String YMH
        {
            get { return PS_YMH; }
            set { PS_YMH = value; }
        }
        String PS_YMV = "PS_YMV";

        public String YMV
        {
            get { return PS_YMV; }
            set { PS_YMV = value; }
        }

        String PS_PRH = "PS_PRH";

        public String PRH
        {
            get { return PS_PRH; }
            set { PS_PRH = value; }
        }
        String PS_PRV = "PS_PRV";

        public String PRV
        {
            get { return PS_PRV; }
            set { PS_PRV = value; }
        }


        String PS_MHS = "PS_MHS";

        String PS_BI = "PS_BI";
        String PS_E = "PS_E";
        String PS_G = "PS_G";
        String PS_D = "PS_D";

        String PS_AA = "PS_AA";

        public String AA
        {
            get { return PS_AA; }
            set { PS_AA = value; }
        }

        String PS_VS = "PS_VS";
        /*Constant values*/

        private const float PS_g = (float)9.80665;
        private const float PS_WaterDensity = (float)1000.0;

        private const int PS_FUNC_NO_VSH = 0;
        private const int PS_FUNC_NO_DP = 1;
        private const int PS_FUNC_NO_TOC_1 = 2;
        private const int PS_FUNC_NO_TOC_2 = 3;
        private const int PS_FUNC_NO_CP = 4;
        private const int PS_FUNC_NO_FP = 5;
        private const int PS_FUNC_NO_SP = 6;
        private const int PS_FUNC_NO_OP = 7;
        private const int PS_FUNC_NO_YM = 8;
        private const int PS_FUNC_NO_PR = 9;
        private const int PS_FUNC_NO_BI = 10;
        private const int PS_FUNC_NO_AM = 11;
        private const int PS_FUNC_NO_MAM = 12;
        private const int PS_FUNC_NO_E = 13;
        private const int PS_FUNC_NO_G = 14;
        private const int PS_FUNC_NO_AA = 15;
        private const int PS_FUNC_NO_VS = 16;
        private const int PS_FUNC_NO_MHS = 17;

        /**********************************************************/

        /*******************Functions of the Class***********************/

        //Constructor
        public FracScopeModel()
        {
            PS_proj = PetrelProject.PrimaryProject;
            PS_WlRoot = WellRoot.Get(PS_proj);
        }






        [Description("PS_Proj", "Project Variable")]
        public Project Project
        {
            internal get { return this.PS_proj; }
            set { this.PS_proj = value; }
        }

        [Description("PS_WlRoot", "Selected Well Root")]
        public Slb.Ocean.Petrel.DomainObject.Well.WellRoot WellRoot
        {
            internal get { return this.PS_WlRoot; }
            set { this.PS_WlRoot = value; }
        }

        [Description("PS_bh", "Selected Bore Hole / Well")]
        public Borehole Borehole
        {
            internal get { return this.PS_bh; }
            set { this.PS_bh = value; }
        }


        [Description("PS_VolumeOfShale", "Volume of Shale Log")]
        public WellLog VolumeOfShale
        {
            internal get { return this.PS_VolumeOfShale; }
            set { this.PS_VolumeOfShale = value; }
        }

        [Description("PS_DensityPorosity", "Density Porosity Well Log")]
        public WellLog DensityPorosity
        {
            internal get { return this.PS_DensityPorosity; }
            set { this.PS_DensityPorosity = value; }
        }

        [Description("PS_KerogenContent", "Kerogen Content Well Log")]
        public WellLog KerogenContent
        {
            internal get { return this.PS_KerogenContent; }
            set { this.PS_KerogenContent = value; }
        }

        [Description("PS_TotalOrganicCarbon", "Total Organic Carbon Well Log")]
        public WellLog TotalOrganicCarbon
        {
            internal get { return this.PS_TotalOrganicCarbon; }
            set { this.PS_TotalOrganicCarbon = value; }
        }

        [Description("PS_ClayPorosity", "Clay Porosity Log")]
        public WellLog ClayPorosity
        {
            internal get { return this.PS_ClayPorosity; }
            set { this.PS_ClayPorosity = value; }
        }

        [Description("PS_FracturePorosity", "Fracture Porosity Well Log")]
        public WellLog FracturePorosity
        {
            internal get { return this.PS_FracturePorosity; }
            set { this.PS_FracturePorosity = value; }
        }

        [Description("PS_OrganicPorosity", "Organic Porosity Well Log")]
        public WellLog OrganicPorosity
        {
            internal get { return this.PS_OrganicPorosity; }
            set { this.PS_OrganicPorosity = value; }
        }

        [Description("PS_InterParticlePorosity", "Inter Particle Porosity Well Log")]
        public WellLog InterParticlePorosity
        {
            internal get { return this.PS_InterParticlePorosity; }
            set { this.PS_InterParticlePorosity = value; }
        }

        [Description("PS_YoungModulas", "Young Modulas Well Log")]
        public WellLog YoungModulas
        {
            internal get { return this.PS_YoungModulas; }
            set { this.PS_YoungModulas = value; }
        }

        [Description("PS_PoissonRatio", "Poisson Ratio Well Log")]
        public WellLog PoissonRatio
        {
            internal get { return this.PS_PoissonRatio; }
            set { this.PS_PoissonRatio = value; }
        }


        public WellLog YoungModulasHorizontal
        {
            get { return PS_YoungModulasHorizontal; }
            set { PS_YoungModulasHorizontal = value; }
        }

        [Description("PS_C33WellLog", "C33 Well Log")]
        public WellLog C33WellLog
        {
            get { return PS_C33WellLog; }
            set { PS_C33WellLog = value; }
        }


        [Description("PS_C44WellLog", "C44 Well Log")]
        public WellLog C44WellLog
        {
            get { return PS_C44WellLog; }
            set { PS_C44WellLog = value; }
        }

        [Description("PS_C66WellLog", "C66 Well Log")]
        public WellLog C66WellLog
        {
            get { return PS_C66WellLog; }
            set { PS_C66WellLog = value; }
        }

        [Description("PS_C13WellLog", "C13 Well Log")]
        public WellLog C13WellLog
        {
            get { return PS_C13WellLog; }
            set { PS_C13WellLog = value; }
        }

        [Description("PS_C12WellLog", "C12 Well Log")]
        public WellLog C12WellLog
        {
            get { return PS_C12WellLog; }
            set { PS_C12WellLog = value; }
        }


        [Description("PS_C11WellLog", "C11 Well Log")]
        public WellLog C11WellLog
        {
            get { return PS_C11WellLog; }
            set { PS_C11WellLog = value; }
        }

        [Description("PS_BrittlenessIndex", "BrittlenessIndex Well Log")]
        public WellLog BrittlenessIndex
        {
            internal get { return this.PS_BrittlenessIndex; }
            set { this.PS_BrittlenessIndex = value; }
        }

        [Description("PS_Epsilon", "Epsilon Well Log")]
        public WellLog Epsilon
        {
            internal get { return this.PS_Epsilon; }
            set { this.PS_Epsilon = value; }
        }

        [Description("PS_Gamma", "Gamma Well Log")]
        public WellLog Gamma
        {
            internal get { return this.PS_Gamma; }
            set { this.PS_Gamma = value; }
        }

        [Description("PS_Delta", "Delta Well Log")]
        public WellLog Delta
        {
            internal get { return this.PS_Delta; }
            set { this.PS_Delta = value; }
        }


        //Converts Units to UI unit from default ocean unit(mks)
        public double PS_ConvertToUI(double value)
        {
            IUnitConverter convertToDisplayMD = PetrelUnitSystem.GetConverterToUI(Domain.MD);

            return convertToDisplayMD.Convert(value);

        }

        //Converts Units to UI unit from default ocean unit(mks)
        public double PS_ConvertFromUI(double value)
        {
            IUnitConverter convertToDisplayMD = PetrelUnitSystem.GetConverterFromUI(Domain.MD);
            return convertToDisplayMD.Convert(value);
        }

        //Check Reservoir Top & Botto, range for a single log
        public Boolean IsUniformSingleWell(WellLog Log, double ReservoirTop, double ReservoirBottom, Boolean ReservoirTopGiven, Boolean ReservoirBottomGiven)
        {
            if (ReservoirTopGiven && ReservoirBottomGiven)
            {
                if (!(this.CheckRange(Log, ReservoirTop, "Reservoir Top") && this.CheckRange(Log, ReservoirBottom, "Reservoir Bottom")))
                {
                    return false;
                }
            }
            else if (ReservoirTopGiven)
            {
                if (!this.CheckRange(Log, ReservoirTop, "Reservoir Top"))
                {
                    return false;
                }
            }
            else if (ReservoirBottomGiven)
            {
                if (!this.CheckRange(Log, ReservoirBottom, "Reservoir Bottom"))
                {
                    return false;
                }
            }
            return true;
        }

        //Check if  Two Logs are uniform interms of Start & End Measured Depth and No. of Samples
        public Boolean IsUniformBetween2(WellLog Log1, WellLog Log2, double ReservoirTop, double ReservoirBottom, Boolean ReservoirTopGiven, Boolean ReservoirBottomGiven)
        {
            int _tmpRTLog1Index, _tmpRTLog2Index, _tmpRBLog1Index, _tmpRBLog2Index;
            Boolean _Uniform = false;
            //Log1.Samples.e
            if (ReservoirTopGiven && ReservoirBottomGiven)
            {

                if (!(this.CheckRange(Log1, ReservoirTop, "Reservoir Top") && this.CheckRange(Log1, ReservoirBottom, "Reservoir Bottom") && this.CheckRange(Log2, ReservoirTop, "Reservoir Top") && this.CheckRange(Log2, ReservoirBottom, "Reservoir Bottom")))
                {
                    return false;
                }

                _tmpRTLog1Index = (int)Math.Round(Log1.IndexAtMD(ReservoirTop));
                _tmpRTLog2Index = (int)Math.Round(Log2.IndexAtMD(ReservoirTop));

                _tmpRBLog1Index = (int)Math.Round(Log1.IndexAtMD(ReservoirBottom));
                _tmpRBLog2Index = (int)Math.Round(Log2.IndexAtMD(ReservoirBottom));

                if ((_tmpRBLog1Index - _tmpRTLog1Index) == (_tmpRBLog2Index - _tmpRTLog2Index))
                {
                    _Uniform = true;
                    return _Uniform;
                }
                PetrelLogger.WarnBox(Log1.Name + " And " + Log2.Name + " are not Uniform, These Logs must have similar Start MD, End MD and no. of elements");

                return false;

            }

            else if (ReservoirTopGiven)
            {
                Boolean _tmp1, _tmp2;
                _tmp1 = this.CheckRange(Log1, ReservoirTop, "Reservoir Top");
                _tmp2 = this.CheckRange(Log2, ReservoirTop, "Reservoir Top");

                if (!(this.CheckRange(Log1, ReservoirTop, "Reservoir Top") && this.CheckRange(Log2, ReservoirTop, "Reservoir Top")))
                {
                    return false;
                }

                _tmpRTLog1Index = (int)Math.Round(Log1.IndexAtMD(ReservoirTop));
                _tmpRTLog2Index = (int)Math.Round(Log2.IndexAtMD(ReservoirTop));

                _tmpRBLog1Index = (int)Math.Round(Log1.IndexAtMD(Log1.Samples.Last<WellLogSample>().MD));
                _tmpRBLog2Index = (int)Math.Round(Log2.IndexAtMD(Log2.Samples.Last<WellLogSample>().MD));

                if ((_tmpRBLog1Index - _tmpRTLog1Index) == (_tmpRBLog2Index - _tmpRTLog2Index))
                {
                    _Uniform = true;
                    return _Uniform;
                }
                PetrelLogger.WarnBox(Log1.Name + " And " + Log2.Name + " are not Uniform, These Logs must have similar Start MD, End MD and no. of elements");

                return false;
            }

            else if (ReservoirBottomGiven)
            {
                Boolean _tmp3, _tmp4;

                _tmp3 = this.CheckRange(Log1, ReservoirBottom, "Reservoir Bottom");
                _tmp4 = this.CheckRange(Log2, ReservoirBottom, "Reservoir Bottom");

                if (!(this.CheckRange(Log1, ReservoirBottom, "Reservoir Bottom") && this.CheckRange(Log2, ReservoirBottom, "Reservoir Bottom")))
                {
                    return false;
                }

                _tmpRTLog1Index = (int)Math.Round(Log1.IndexAtMD(Log1.Samples.First<WellLogSample>().MD));
                _tmpRTLog2Index = (int)Math.Round(Log2.IndexAtMD(Log2.Samples.First<WellLogSample>().MD));

                _tmpRBLog1Index = (int)Math.Round(Log1.IndexAtMD(ReservoirBottom));
                _tmpRBLog2Index = (int)Math.Round(Log2.IndexAtMD(ReservoirBottom));

                if ((_tmpRBLog1Index - _tmpRTLog1Index) == (_tmpRBLog2Index - _tmpRTLog2Index))
                {
                    _Uniform = true;
                    return _Uniform;
                }
                PetrelLogger.WarnBox(Log1.Name + " And " + Log2.Name + " are not Uniform, These Logs must have similar Start MD, End MD and no. of elements");
                return false;
            }
            else
            {
                if ((Log1.Samples.First<WellLogSample>().MD == Log2.Samples.First<WellLogSample>().MD) && (Log1.Samples.Last<WellLogSample>().MD == Log2.Samples.Last<WellLogSample>().MD) && (Log1.SampleCount == Log2.SampleCount))
                {
                    return true;
                }
                else
                {
                    PetrelLogger.WarnBox(Log1.Name + " And " + Log2.Name + " are not Uniform, These Logs must have similar Start MD, End MD and no. of elements");
                    return false;
                }
            }

        }

        //Check if  Two Logs are uniform interms of Start & End Measured Depth and No. of Samples
        public Boolean IsUniformAmong3(WellLog Log1, WellLog Log2, WellLog Log3, double ReservoirTop, double ReservoirBottom, Boolean ReservoirTopGiven, Boolean ReservoirBottomGiven)
        {
            if (IsUniformBetween2(Log1, Log2, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven) && IsUniformBetween2(Log2, Log3, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Check if More than Two Logs are uniform interms of Start & End Measured Depth and No. of Samples
        public Boolean IsUniform(List<WellLog> LogCollection, double ReservoirTop, double ReservoirBottom, Boolean ReservoirTopGiven, Boolean ReservoirBottomGiven)
        {
            for (int i = 0; i < LogCollection.Count - 1; i++)
            {
                if (!IsUniformBetween2(LogCollection[i], LogCollection[i + 1], ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven))
                {
                    return false;
                }
            }
            return true;
        }

        //Decidesw whether logs exist in the given Borehole
        public Boolean LogsExist(Borehole bh, List<WellLogVersion> wlVersion)
        {
            int _logCount = wlVersion.Count;

            List<Boolean> _exists = new List<bool>();
            for (int i = 0; i < _logCount; i++)
            {
                _exists.Add(false);
            }

            //Check if each of the welllog version exists in the current welllog
            for (int i = 0; i < _logCount; i++)
            {
                foreach (WellLogVersion _localWlLogVersion in bh.Logs.AllWellLogVersions)
                {
                    if (wlVersion[i].Name.Equals(_localWlLogVersion.Name))
                    {
                        _exists[i] = true;
                        break;
                    }
                }
            }

            Boolean _result = _exists[0];
            for (int i = 0; i < _logCount - 1; i++)
            {
                if (_exists[i] && _exists[i + 1])
                {
                    _result = true;
                }
                else
                {
                    return false;
                }
            }

            return _result;
        }

        //A resursive function to check and provide an unused Well Log Version Name
        public String FindUniqueWellLogVersionName(Borehole bh, String WlVersionName, Template wlvTemplate)
        {
            /*Creating Output Well Log*/
            /*Check if the well log version exists */

            IEnumerable<WellLog> _WellColl = bh.Logs.WellLogs;//FindUnusedWellLogVersions(wlvTemplate);
            if (_WellColl.Count() > 0)
            {

                foreach (WellLog _tmpWell in _WellColl)
                {
                    //If the Well log version exists create a new well log version name
                    if (_tmpWell.WellLogVersion.Name.Equals(WlVersionName))
                    {
                        Random _rand = new Random();
                        String _tmpNum = _rand.NextDouble().ToString();
                        WlVersionName = WlVersionName + "_" + _tmpNum;
                        return FindUniqueWellLogVersionName(bh, WlVersionName, wlvTemplate);
                    }

                }
                return WlVersionName;
            }
            else
            {
                return WlVersionName;
            }
        }

        //Creates a Well Log
        public WellLog CreateWellLog(Borehole bh, String WlVersionName, Template wlvTemplate)
        {
            WellLog _log;
            WellLogVersion _wlVersion = WellLogVersion.NullObject;
            Boolean _WLVersionExist = false;

            /*Creating Output Well Log*/
            /*Check if the well log version exists */

            //Find a unique Well Log Name
            WlVersionName = this.FindUniqueWellLogVersionName(bh, WlVersionName, wlvTemplate);

            LogVersionCollection _rootLVColl = this.PS_WlRoot.LogVersionCollection;

            //Check If the Well Log Version Exists in the Global Well Log
            try
            {
                foreach (WellLogVersion _tmpWLVersion in _rootLVColl.WellLogVersions)
                {
                    if (_tmpWLVersion.Name.Equals(WlVersionName))
                    {
                        _WLVersionExist = true;
                        _wlVersion = _tmpWLVersion;
                        break;
                    }
                }

                //If not Create One
                if (!_WLVersionExist)
                {
                    using (ITransaction trans = DataManager.NewTransaction())
                    {
                        trans.Lock(_rootLVColl);
                        _wlVersion = _rootLVColl.CreateWellLogVersion(WlVersionName, wlvTemplate);
                        trans.Commit();
                    }
                }

                //Create Well Log
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(bh);
                    _log = bh.Logs.CreateWellLog(_wlVersion);
                    trans.Commit();
                }
                return _log;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                throw;
            }
        }

        /*Checks Wheather the Depth within the Measured Depth Range of the selected WellLog*/
        public Boolean CheckRange(WellLog log, double MeasuredDepth, String Property)
        {
            if ((MeasuredDepth < log.Samples.First<WellLogSample>().MD) || (MeasuredDepth > log.Samples.Last<WellLogSample>().MD))
            {
                PetrelLogger.WarnBox(Property + " is not within the range of " + log.Name + ", Please Select a Value within " + PS_ConvertToUI(log.Samples.First<WellLogSample>().MD).ToString() + "and " + PS_ConvertToUI(log.Samples.Last<WellLogSample>().MD).ToString());
                return false;
            }
            else
            {
                return true;
            }
        }

        //Gets the int index of a measured depth in a Well Log
        public int Index(WellLog log, double MD)
        {
            double _dIndex;
            int _index;

            _dIndex = log.IndexAtMD(MD);
            _index = (int)Math.Round(_dIndex);

            return _index;

        }

        //Getting Reservoir Top Bottom for Calculation
        public void GetReservoirTopBottom(WellLog log, double ReservoirTop, double ReservoirBottom, Boolean ReservoirTopGiven, Boolean ReservoirBottomGiven, ref int TopIndex, ref int BottomIndex)
        {
            double _dIndexRT, _dIndexRB; //Double index for Reservoir Top and bottom

            //Calculate the start and End Index
            if (ReservoirTopGiven && ReservoirBottomGiven)
            {
                _dIndexRT = log.IndexAtMD(ReservoirTop);
                _dIndexRB = log.IndexAtMD(ReservoirBottom);

                TopIndex = (int)Math.Round(_dIndexRT);
                BottomIndex = (int)Math.Round(_dIndexRB);
            }

            else if (ReservoirTopGiven)
            {
                _dIndexRT = log.IndexAtMD(ReservoirTop);
                _dIndexRB = log.IndexAtMD(log.Samples.Last<WellLogSample>().MD);
                TopIndex = (int)Math.Round(_dIndexRT);
                BottomIndex = (int)Math.Round(_dIndexRB);
            }

            else if (ReservoirBottomGiven)
            {
                _dIndexRT = log.IndexAtMD(log.Samples.First<WellLogSample>().MD);
                _dIndexRB = log.IndexAtMD(ReservoirBottom);

                TopIndex = (int)Math.Round(_dIndexRT);
                BottomIndex = (int)Math.Round(_dIndexRB);
            }

            else
            {
                _dIndexRT = log.IndexAtMD(log.Samples.First<WellLogSample>().MD);
                _dIndexRB = log.IndexAtMD(log.Samples.Last<WellLogSample>().MD);

                TopIndex = (int)Math.Round(_dIndexRT);
                BottomIndex = (int)Math.Round(_dIndexRB);
            }
        }

        //Traverses through Wells for multiple well Log calculation
        public void TraverseThroughWells(BoreholeCollection bhC, List<WellLogVersion> wlV, Input input, int funcNo)
        {
            //Now loop over all the boreholes (Wells)
            if (bhC.BoreholeCollectionCount > 0)
            {
                foreach (BoreholeCollection _tmpBC in bhC.BoreholeCollections)
                {
                    TraverseThroughWells(_tmpBC, wlV, input, funcNo);
                }
            }

            else
            {
                foreach (Borehole well in bhC)
                {
                    Boolean _exists = true;
                    List<WellLog> _wellLogColl = new List<WellLog>();

                    for (int i = 0; i < wlV.Count; i++)
                    {
                        WellLog _tmpWlLog = well.Logs.GetWellLog(wlV[i]);
                        if (_tmpWlLog != WellLog.NullObject)
                        {
                            _wellLogColl.Add(_tmpWlLog);
                        }
                        else
                        {
                            _exists = false;
                        }
                    }

                    if (_exists)
                    {
                        switch (funcNo)
                        {
                            case 0:
                                Calculate_VolumeOfShale(well, _wellLogColl[1], _wellLogColl[0], input.ReservoirTop, input.ReservoirBottom, input.ReservoirTopGiven, input.ReservoirBottomGiven, input.UserDepth, input.OutputFileName);
                                break;
                            case 1:
                                Calculate_DensityPorosity(well, _wellLogColl[0], input.ReservoirTop, input.ReservoirBottom, input.ReservoirTopGiven, input.ReservoirBottomGiven, input.DensityMatrix, input.DensityOfFluid, input.OutputFileName);
                                break;
                            case 2:
                                Calculate_TotalOrganicCarbon(well, _wellLogColl[0], input.ReservoirTop, input.ReservoirBottom, input.ReservoirTopGiven, input.ReservoirBottomGiven, input.StartDepthOfNonkerogenShale, input.EndDepthOfNonKerogenShale, input.AssumedMatrixDensity, input.AssumedKerogenDensity, input.DensityOfBrine, input.OutputFileName);
                                break;
                            case 3:
                                Calculate_TotalOrganicCarbon_2(well, _wellLogColl[0], input.ReservoirTop, input.ReservoirBottom, input.ReservoirTopGiven, input.ReservoirBottomGiven, input.GrainDensity, input.OutputFileName);
                                break;
                            case 4:
                                Calculate_ClayPorosity(well, _wellLogColl[0], _wellLogColl[1], input.ReservoirTop, input.ReservoirBottom, input.ReservoirTopGiven, input.ReservoirBottomGiven, input.OutputFileName);
                                break;
                            case 5:
                                Calculate_FracturePorosity(well, _wellLogColl[0], input.ReservoirTop, input.ReservoirBottom, input.ReservoirTopGiven, input.ReservoirBottomGiven, input.Constant, input.OutputFileName);
                                break;
                            case 6:
                                Calculate_SandPorosity(well, _wellLogColl[0], _wellLogColl[1], _wellLogColl[2], _wellLogColl[3], _wellLogColl[4], input.ReservoirTop, input.ReservoirBottom, input.ReservoirTopGiven, input.ReservoirBottomGiven, input.OutputFileName);
                                break;
                            case 7:
                                Calculate_OrganicPorosity(well, _wellLogColl[0], input.ReservoirTop, input.ReservoirBottom, input.ReservoirTopGiven, input.ReservoirBottomGiven, input.StartDepthOfNonkerogenShale, input.EndDepthOfNonKerogenShale, input.AssumedMatrixDensity, input.AssumedKerogenDensity, input.OutputFileName);
                                break;
                            case 8:
                                Calculate_YoungModulas(well, _wellLogColl[0], _wellLogColl[1], _wellLogColl[2], input.ReservoirTop, input.ReservoirBottom, input.ReservoirTopGiven, input.ReservoirBottomGiven, input.OutputFileName);
                                break;
                            case 9:
                                Calculate_PoissonRatio(well, _wellLogColl[0], _wellLogColl[1], input.ReservoirTop, input.ReservoirBottom, input.ReservoirTopGiven, input.ReservoirBottomGiven, input.OutputFileName);
                                break;
                            case 10:
                                Calculate_BrittlenessIndex(well, _wellLogColl[0], _wellLogColl[1], input.ReservoirTop, input.ReservoirBottom, input.ReservoirTopGiven, input.ReservoirBottomGiven, input.OutputFileName);
                                break;
                            case 11:
                                Calculate_PoissonRatio_YoungModulas_AnnieModel(well, _wellLogColl[0], _wellLogColl[1], _wellLogColl[2], _wellLogColl[3], _wellLogColl[4], _wellLogColl[5], input.ReservoirTop, input.ReservoirBottom, input.ReservoirTopGiven, input.ReservoirBottomGiven, input.BiotConstant, input.PoreElasticConstant, input.MinHorStrain, input.MaxHorStrain, input.OutputFileNameList);
                                break;
                            case 12:
                                Calculate_PoissonRatio_YoungModulas_Modified_AnnieModel(well, _wellLogColl[0], _wellLogColl[1], _wellLogColl[2], _wellLogColl[3], _wellLogColl[4], _wellLogColl[5], input.ReservoirTop, input.ReservoirBottom, input.ReservoirTopGiven, input.ReservoirBottomGiven, input.Constant1, input.Constant2, input.BiotConstant, input.PoreElasticConstant, input.MinHorStrain, input.MaxHorStrain, input.OutputFileNameList);
                                break;
                            case 13:
                                Calculate_Epsilon(well, _wellLogColl[0], _wellLogColl[1], input.ReservoirTop, input.ReservoirBottom, input.ReservoirTopGiven, input.ReservoirBottomGiven, input.OutputFileName);
                                break;
                            case 14:
                                Calculate_Gamma(well, _wellLogColl[0], _wellLogColl[1], input.ReservoirTop, input.ReservoirBottom, input.ReservoirTopGiven, input.ReservoirBottomGiven, input.OutputFileName);
                                break;
                            case 15:
                                Calculate_AzimuthalAnisotropy(well, _wellLogColl[0], _wellLogColl[1], input.ReservoirTop, input.ReservoirBottom, input.ReservoirTopGiven, input.ReservoirBottomGiven, input.OutputFileName);
                                break;
                            case 16:
                                Calculate_VerticalStress(well, _wellLogColl[0], input.ReservoirTop, input.ReservoirBottom, input.ReservoirTopGiven, input.ReservoirBottomGiven, input.WaterDepth, input.OutputFileName);
                                break;
                            case 17:
                                Calculate_MinHorStress_Isotropic(well, _wellLogColl[0], _wellLogColl[1], _wellLogColl[2], _wellLogColl[3], input.ReservoirTop, input.ReservoirBottom, input.ReservoirTopGiven, input.ReservoirBottomGiven, input.BiotConstant, input.MinHorStrain, input.MaxHorStrain, input.OutputFileName);
                                break;
                            default:
                                break;

                        }

                    }

                }
            }
        }


        /*Calculates Volume of Shale*/
        public Boolean Calculate_VolumeOfShale(Borehole bh, WellLog Neutron, WellLog DensityPorosity, double ReservoirTop, double ReservoirBottom, Boolean ReservoirTopGiven, Boolean ReservoirBottomGiven, double userDepth, String OutputName)
        {
            float _userNeutron, _userDensityPorosity;  //Neutron and DensityPorosity at the userDepth

            List<WellLogSample> _outPutSample = new List<WellLogSample>(); //WellLog Sample Container for the Output Log

            int _iRTNeutron = 0, _iRBNeutron = 0, _iRTDP = 0, _iRBDP = 0;   //For Effective Rservoir Top & Bottom of the logs

            //Setting the Output Name 
            if (OutputName.Length != 0)
            {
                PS_VSH = OutputName;
            }


            if (!(CheckRange(Neutron, userDepth, "User Depth") && CheckRange(DensityPorosity, userDepth, "User Depth")))
            {
                return false;
            }

            //Check Well Logs Uniformity
            if (!IsUniformBetween2(Neutron, DensityPorosity, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven))
            {
                return false;
            }

            //Get the Effective Reservoir Top & Bottom

            GetReservoirTopBottom(Neutron, ReservoirTop, ReservoirBottom, ReservoirBottomGiven, ReservoirBottomGiven, ref _iRTNeutron, ref _iRBNeutron);
            GetReservoirTopBottom(DensityPorosity, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iRTDP, ref _iRBDP);

            double _dIndex_Neutron = Neutron.IndexAtMD(userDepth);
            double _dIndex_DensityPorosity = DensityPorosity.IndexAtMD(userDepth);


            int _index_Neutron = (int)Math.Round(_dIndex_Neutron);
            int _index_DensityPorosity = (int)Math.Round(_dIndex_DensityPorosity);

            //So other than that both of them have value in the measured depth, so we will use any of the index
            _userNeutron = Neutron[_index_Neutron].Value;
            _userDensityPorosity = DensityPorosity[_index_DensityPorosity].Value;

            try
            {
                for (int i = _iRTNeutron, j = _iRTDP; i <= _iRBNeutron; i++, j++)
                {
                    double _tmpMD = Neutron[i].MD;
                    float _tmpValue;

                    _tmpValue = ((Neutron[i].Value - DensityPorosity[j].Value) / (_userNeutron - _userDensityPorosity)) / 1000;

                    WellLogSample _tmpSample = new WellLogSample(_tmpMD, _tmpValue);
                    _outPutSample.Add(_tmpSample);

                }

                /*Creating a New Output Well Log*/
                Template _tmp_wlvTemplate = PetrelProject.WellKnownTemplates.LogTypesGroup.VolumeOfShale;
                PS_VolumeOfShale = CreateWellLog(bh, PS_VSH, _tmp_wlvTemplate);

                //Now add the Newly created samples to the Output Well Log
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_VolumeOfShale);
                    PS_VolumeOfShale.Samples = _outPutSample;
                    trans.Commit();
                }
               return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }
        }

        //Calculating Volume of Shale for Well LogsMultiple 
        public Boolean Calculate_VolumeOfShale_MultipleWellLogs(Input input)
        {
            //Creating a borehole collection object
            BoreholeCollection _bhcolObj = PS_WlRoot.BoreholeCollection;
            List<WellLogVersion> _wlVersionColl = new List<WellLogVersion>();

            _wlVersionColl.Add(input.Wlv1);
            _wlVersionColl.Add(input.Wlv2);

            try
            {
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_WlRoot);
                    _bhcolObj = PS_WlRoot.GetOrCreateBoreholeCollection();
                    trans.Commit();
                }

                TraverseThroughWells(_bhcolObj, _wlVersionColl, input, PS_FUNC_NO_VSH);
                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }

        }

        //Calculate Density Porosity
        public Boolean Calculate_DensityPorosity(Borehole bh, WellLog DensityLog, double ReservoirTop, double ReservoirBottom, Boolean ReservoirTopGiven, Boolean ReservoirBottomGiven, float DensityMatrix, float DensityOfFluid, String OutputName)
        {

            List<WellLogSample> _outPutSample = new List<WellLogSample>(); //WellLog Sample Container for the Output Log
            int _indexRT = 0, _indexRB = 0;


            
            //Setting the Output Name 
            if (OutputName.Length != 0)
            {
                PS_DP = OutputName;
            }
            
            if (!IsUniformSingleWell(DensityLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven))
            {
                return false;
            }
            //Calculate the start and End Index
            GetReservoirTopBottom(DensityLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _indexRT, ref _indexRB);

            try
            {
                for (int i = _indexRT; i <= _indexRB; i++)
                {
                    double _tmpMD = DensityLog[i].MD;
                    float _tmvValue;

                    //Calculating Normalizedf Poisson Ratio and Young Modulas
                    _tmvValue = (DensityMatrix - DensityLog[i].Value) / (DensityMatrix - DensityOfFluid);
                    WellLogSample _tmpSample = new WellLogSample(_tmpMD, _tmvValue);
                    _outPutSample.Add(_tmpSample);

                }

                /*Creating a New Output Well Log*/
                Template _tmp_wlvTemplate = PetrelProject.WellKnownTemplates.PetrophysicalGroup.Porosity;
                PS_DensityPorosity = CreateWellLog(bh, PS_DP, _tmp_wlvTemplate);

                //Now add the Newly created samples to the Output Well Log
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_DensityPorosity);
                    PS_DensityPorosity.Samples = _outPutSample;
                    trans.Commit();
                }

                return true;
            }

            catch (Exception ex)
            {

                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }

        }

        //Calculate Density Porosity for Multiple Well Logs
        public Boolean Calculate_DensityPorosity_MultipleWellLogs(Input input)
        {
            BoreholeCollection _bhcolObj = PS_WlRoot.BoreholeCollection;
            List<WellLogVersion> _wlVersionColl = new List<WellLogVersion>();

            _wlVersionColl.Add(input.Wlv1);

            try
            {
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_WlRoot);
                    _bhcolObj = PS_WlRoot.GetOrCreateBoreholeCollection();
                    trans.Commit();
                }

                TraverseThroughWells(_bhcolObj, _wlVersionColl, input, PS_FUNC_NO_DP);
                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }
        }


        //Calculates Total Organic Carbon
        public Boolean Calculate_TotalOrganicCarbon(Borehole bh, WellLog DensityLog, double ReservoirTop, double ReservoirBottom, Boolean ReservoirTopGiven, Boolean ReservoirBottomGiven, double StartDepthOfNonkerogenShale, double EndDepthOfNonKerogenShale, float AssumedMatrixDensity, float AssumedKerogenDensity, float DensityOfBrine, String OutputName)
        {
            float _DensityOfNonKerogenShale;  //Non Kerogen Shale Density at the DepthOfNonKerogenShale

            List<WellLogSample> _outPutSample = new List<WellLogSample>(); //WellLog Sample Container for the Output Log

            if (!IsUniformSingleWell(DensityLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven))
            {
                return false;
            }

            //Setting the Output Name 
            if (OutputName.Length != 0)
            {
                PS_TOC = OutputName;
            }

            //Calculate the Organic Porosity 
            this.Calculate_OrganicPorosity(bh, DensityLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, StartDepthOfNonkerogenShale, EndDepthOfNonKerogenShale, AssumedMatrixDensity, AssumedKerogenDensity, PS_OP);


            float WaterFilledPorosity;

            //Calculating the Avg DensityOfNonKeroge
            double _dStartIndex_NonKerogenShale = DensityLog.IndexAtMD(StartDepthOfNonkerogenShale);
            double _dEndIndex_NonKerogenShale = DensityLog.IndexAtMD(EndDepthOfNonKerogenShale);

            int _StartIndex_NonKerogenShale = (int)Math.Round(_dStartIndex_NonKerogenShale);
            int _EndIndex_NonKerogenShale = (int)Math.Round(_dEndIndex_NonKerogenShale);

            
            float _tmpSum = 0;
            int _tmpcount = _EndIndex_NonKerogenShale - _StartIndex_NonKerogenShale + 1; //No. of entry for AvgDensityOfNonKerogenShale Calculation

            try
            {
                for (int i = _StartIndex_NonKerogenShale; i <= _EndIndex_NonKerogenShale; i++)
                {
                    _tmpSum = _tmpSum + DensityLog[i].Value;
                }

                //Avg DensityOfNonKerogen
                _DensityOfNonKerogenShale = _tmpSum / _tmpcount;

                //Calculate Water Filled Porosity
                WaterFilledPorosity = (_DensityOfNonKerogenShale - AssumedMatrixDensity) / (DensityOfBrine - AssumedMatrixDensity);

                foreach (WellLogSample _sample in this.PS_OrganicPorosity.Samples)
                {
                    double _tmpMD = _sample.MD;
                    float _tmvValue;
                    _tmvValue = (float)(0.85 * AssumedKerogenDensity * _sample.Value) / ((AssumedKerogenDensity * _sample.Value) + (AssumedMatrixDensity * (1 - WaterFilledPorosity - _sample.Value)));

                    WellLogSample _tmpSample = new WellLogSample(_tmpMD, _tmvValue);
                    _outPutSample.Add(_tmpSample);

                }

                /*Creating a New Output Well Log*/
                Template _tmp_wlvTemplate = PetrelProject.WellKnownTemplates.PetrophysicalGroup.Porosity;
                PS_TotalOrganicCarbon = CreateWellLog(bh, PS_TOC, _tmp_wlvTemplate);

                //Now add the Newly created samples to the Output Well Log
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_TotalOrganicCarbon);
                    PS_TotalOrganicCarbon.Samples = _outPutSample;
                    trans.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }
        }


        //Calculates Total Organic Carbon for Multiple Well Logs
        public Boolean Calculate_TotalOrganicCarbon_MultipleWellLogs(Input input)
        {
            BoreholeCollection _bhcolObj = PS_WlRoot.BoreholeCollection;
            List<WellLogVersion> _wlVersionColl = new List<WellLogVersion>();

            _wlVersionColl.Add(input.Wlv1);

            try
            {
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_WlRoot);
                    _bhcolObj = PS_WlRoot.GetOrCreateBoreholeCollection();
                    trans.Commit();
                }

                TraverseThroughWells(_bhcolObj, _wlVersionColl, input, PS_FUNC_NO_TOC_1);
                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }
        }

        //Calculates TOC Algm2 
        public Boolean Calculate_TotalOrganicCarbon_2(Borehole bh, WellLog DensityLog, double ReservoirTop, double ReservoirBottom, Boolean ReservoirTopGiven, Boolean ReservoirBottomGiven, float GrainDensity, String OutputName)
        {
            List<WellLogSample> _outPutSample = new List<WellLogSample>(); //WellLog Sample Container for the Output Log
            int _indexRT = 0, _indexRB = 0;

            if (!IsUniformSingleWell(DensityLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven))
            {
                return false;
            }

            //Setting the Output Name 
            if (OutputName.Length != 0)
            {
                PS_TOC = OutputName;
            }

            GetReservoirTopBottom(DensityLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _indexRT, ref _indexRB);

            try
            {
                for (int i = _indexRT; i <= _indexRB; i++)
                {
                    double _tmpMD = DensityLog[i].MD;
                    float _tmvValue, _tmpA, _tmpB;
                   
                    _tmpA = (GrainDensity / (GrainDensity - 1));
                    _tmpB = _tmpA - 1;

                    _tmvValue = ((_tmpA*1000 / DensityLog[i].Value) - _tmpB);


                    WellLogSample _tmpSample = new WellLogSample(_tmpMD, _tmvValue);
                    _outPutSample.Add(_tmpSample);
                }

                /*Creating a New Output Well Log*/
                Template _tmp_wlvTemplate = PetrelProject.WellKnownTemplates.PetrophysicalGroup.Porosity;
                PS_TotalOrganicCarbon = CreateWellLog(bh, PS_TOC, _tmp_wlvTemplate);

                //Now add the Newly created samples to the Output Well Log
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_TotalOrganicCarbon);
                    PS_TotalOrganicCarbon.Samples = _outPutSample;
                    trans.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }
        }

        //Calculates Total Organic Carbon for Multiple Well Logs using Algm 2
        public Boolean Calculate_TotalOrganicCarbon_2_MultipleWellLogs(Input input)
        {
            BoreholeCollection _bhcolObj = PS_WlRoot.BoreholeCollection;
            List<WellLogVersion> _wlVersionColl = new List<WellLogVersion>();

            _wlVersionColl.Add(input.Wlv1);

            try
            {
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_WlRoot);
                    _bhcolObj = PS_WlRoot.GetOrCreateBoreholeCollection();
                    trans.Commit();
                }

                TraverseThroughWells(_bhcolObj, _wlVersionColl, input, PS_FUNC_NO_TOC_2);
                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }
        }


        //Calculates Clay Porosity
        public Boolean Calculate_ClayPorosity(Borehole bh, WellLog VolumeOfShale, WellLog DensityPorosity, double ReservoirTop, double ReservoirBottom, Boolean ReservoirTopGiven, Boolean ReservoirBottomGiven, String OutputName)
        {
            List<WellLogSample> _outPutSample = new List<WellLogSample>(); //WellLog Sample Container for the Output Log
            int _iVSRT = 0, _iVSRB = 0, _iDPRT = 0, _iDPRB = 0;

             //Check Well Logs Uniformity
            if (!IsUniformBetween2(VolumeOfShale, DensityPorosity, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven))
            {
                return false;
            }

            //Setting the Output Name 
            if (OutputName.Length != 0)
            {
                PS_CP = OutputName;
            }

            //Calculate the start and End Index
            GetReservoirTopBottom(VolumeOfShale, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iVSRT, ref _iVSRB);
            GetReservoirTopBottom(DensityPorosity, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iDPRT, ref _iDPRB);

            try
            {
                for (int i = _iVSRT, j = _iDPRT; i <= _iVSRB; i++, j++)
                {
                    double _tmpMD = VolumeOfShale[i].MD;
                    float _tmvValue;

                    //Calculating Normalizedf Poisson Ratio and Young Modulas
                    _tmvValue = VolumeOfShale[i].Value * DensityPorosity[j].Value;
                    WellLogSample _tmpSample = new WellLogSample(_tmpMD, _tmvValue);
                    _outPutSample.Add(_tmpSample);
                }

                /*Creating a New Output Well Log*/
                //Confused About Template Type
                Template _tmp_wlvTemplate = PetrelProject.WellKnownTemplates.PetrophysicalGroup.Porosity;
                PS_ClayPorosity = CreateWellLog(bh, PS_CP, _tmp_wlvTemplate);

                //Now add the Newly created samples to the Output Well Log
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_ClayPorosity);
                    PS_ClayPorosity.Samples = _outPutSample;
                    trans.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }
        }


        //Calculates Total ClayPorosity for Multiple Well Logs using Algm 2
        public Boolean Calculate_ClayPorosity_MultipleWellLogs(Input input)
        {
            BoreholeCollection _bhcolObj = PS_WlRoot.BoreholeCollection;
            List<WellLogVersion> _wlVersionColl = new List<WellLogVersion>();

            _wlVersionColl.Add(input.Wlv1);
            _wlVersionColl.Add(input.Wlv2);

            try
            {
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_WlRoot);
                    _bhcolObj = PS_WlRoot.GetOrCreateBoreholeCollection();
                    trans.Commit();
                }

                TraverseThroughWells(_bhcolObj, _wlVersionColl, input, PS_FUNC_NO_CP);
                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }
        }


        //Calculate fracture Porosity
        public Boolean Calculate_FracturePorosity(Borehole bh, WellLog FractureDensityLog, double ReservoirTop, double ReservoirBottom, Boolean ReservoirTopGiven, Boolean ReservoirBottomGiven, float Constant, String OutputName)
        {
            List<WellLogSample> _outPutSample = new List<WellLogSample>(); //WellLog Sample Container for the Output Log

            int _iRTFrac = 0, _iRBFrac = 0;   //For Effective Rservoir Top & Bottom of the logs

            if (!IsUniformSingleWell(FractureDensityLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven))
            {
                return false;
            }

            //Setting the Output Name 
            if (OutputName.Length != 0)
            {
                PS_FP = OutputName;
            }

            //Get the Effective Reservoir Top & Bottom
            GetReservoirTopBottom(FractureDensityLog, ReservoirTop, ReservoirBottom, ReservoirBottomGiven, ReservoirBottomGiven, ref _iRTFrac, ref _iRBFrac);

            try
            {
                for (int i = _iRTFrac; i <= _iRBFrac; i++)
                {
                    double _tmpMD = FractureDensityLog[i].MD;
                    float _tmpValue;

                    _tmpValue = FractureDensityLog[i].Value * Constant;

                    WellLogSample _tmpSample = new WellLogSample(_tmpMD, _tmpValue);
                    _outPutSample.Add(_tmpSample);

                }

                /*Creating a New Output Well Log*/
                Template _tmp_wlvTemplate = PetrelProject.WellKnownTemplates.PetrophysicalGroup.Porosity;
                PS_FracturePorosity = CreateWellLog(bh, PS_FP, _tmp_wlvTemplate);

                //Now add the Newly created samples to the Output Well Log
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_FracturePorosity);
                    PS_FracturePorosity.Samples = _outPutSample;
                    trans.Commit();
                }
                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }
        }

        //Calculates Total ClayPorosity for Multiple Well Logs using Algm 2
        public Boolean Calculate_FracturePorosity_MultipleWellLogs(Input input)
        {
            BoreholeCollection _bhcolObj = PS_WlRoot.BoreholeCollection;
            List<WellLogVersion> _wlVersionColl = new List<WellLogVersion>();

            _wlVersionColl.Add(input.Wlv1);

            try
            {
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_WlRoot);
                    _bhcolObj = PS_WlRoot.GetOrCreateBoreholeCollection();
                    trans.Commit();
                }

                TraverseThroughWells(_bhcolObj, _wlVersionColl, input, PS_FUNC_NO_FP);
                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }
        }


        //Calculate Toatal Porosity
        public Boolean Calculate_TotalPorosity(Borehole bh, WellLog DensityporosityLog, WellLog FracturePorosityLog, WellLog OrganicPorosityLog, double ReservoirTop, double ReservoirBottom, Boolean ReservoirTopGiven, Boolean ReservoirBottomGiven, String OutputName)
        {
            List<WellLogSample> _outPutSample = new List<WellLogSample>(); //WellLog Sample Container for the Output Log
            int _iRTDP = 0, _iRBDP = 0, _iRTFP = 0, _iRBFP = 0, _iRTOP = 0, _iRBOP = 0;

            //Check Well Logs Uniformity
            if (!IsUniformAmong3(DensityporosityLog, FracturePorosityLog, OrganicPorosityLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven))
            {
                return false;
            }

            //Setting the Output Name 
            if (OutputName.Length != 0)
            {
                PS_TP = OutputName;
            }

            //Calculate the start and End Index
            GetReservoirTopBottom(DensityporosityLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iRTDP, ref _iRBDP);
            GetReservoirTopBottom(FracturePorosityLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iRTFP, ref _iRBFP);
            GetReservoirTopBottom(OrganicPorosityLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iRTOP, ref _iRBOP);

            try
            {
                for (int i = _iRTDP, j = _iRTFP, k = _iRTOP; i <= _iRBDP; i++, j++, k++)
                {
                    double _tmpMD = DensityporosityLog[i].MD;
                    float _tmvValue;

                    _tmvValue = DensityporosityLog[i].Value - FracturePorosityLog[j].Value - OrganicPorosityLog[k].Value;
                    WellLogSample _tmpSample = new WellLogSample(_tmpMD, _tmvValue);
                    _outPutSample.Add(_tmpSample);

                }

                /*Creating a New Output Well Log*/
                Template _tmp_wlvTemplate = PetrelProject.WellKnownTemplates.PetrophysicalGroup.Porosity;
                PS_TotalPorosity = CreateWellLog(bh, PS_TP, _tmp_wlvTemplate);

                //Now add the Newly created samples to the Output Well Log
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_TotalPorosity);
                    PS_TotalPorosity.Samples = _outPutSample;
                    trans.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }
        }

        //Calculate Sand Porosity
        public Boolean Calculate_SandPorosity(Borehole bh, WellLog DensityporosityLog, WellLog FracturePorosityLog, WellLog OrganicPorosityLog, WellLog ClayPorosityLog, WellLog VolumeOfShaleLog, double ReservoirTop, double ReservoirBottom, Boolean ReservoirTopGiven, Boolean ReservoirBottomGiven, String OutputName)
        {
            List<WellLogSample> _outPutSample = new List<WellLogSample>(); //WellLog Sample Container for the Output Log
            int _iRTDP = 0, _iRBDP = 0, _iRTFP = 0, _iRBFP = 0, _iRTOP = 0, _iRBOP = 0, _iRTCP = 0, _iRBCP = 0, _iRTVsh = 0, _iRBVsh = 0;

            List<WellLog> _logs = new List<WellLog>();
            _logs.Add(DensityporosityLog);
            _logs.Add(FracturePorosityLog);
            _logs.Add(OrganicPorosityLog);
            _logs.Add(ClayPorosityLog);
            _logs.Add(VolumeOfShaleLog);
            //Check Well Logs Uniformity
            if (!IsUniform(_logs, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven))
            {
                return false;
            }

            //Setting the Output Name 
            if (OutputName.Length != 0)
            {
                PS_SP = OutputName;
            }

            //Calculate the start and End Index
            GetReservoirTopBottom(DensityporosityLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iRTDP, ref _iRBDP);
            GetReservoirTopBottom(FracturePorosityLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iRTFP, ref _iRBFP);
            GetReservoirTopBottom(OrganicPorosityLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iRTOP, ref _iRBOP);
            GetReservoirTopBottom(ClayPorosityLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iRTCP, ref _iRBCP);
            GetReservoirTopBottom(VolumeOfShaleLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iRTVsh, ref _iRBVsh);
            try
            {
                for (int i = _iRTDP, j = _iRTFP, k = _iRTOP, l = _iRTCP, m = _iRTVsh; i <= _iRBDP; i++, j++, k++, l++, m++)
                {
                    double _tmpMD = DensityporosityLog[i].MD;
                    float _totPor, _tmvValue;
                    _totPor = DensityporosityLog[i].Value - FracturePorosityLog[j].Value - OrganicPorosityLog[k].Value;
                    _tmvValue = (_totPor - (VolumeOfShaleLog[m].Value * ClayPorosityLog[l].Value)) / (1 - VolumeOfShaleLog[m].Value);
                    WellLogSample _tmpSample = new WellLogSample(_tmpMD, _tmvValue);
                    _outPutSample.Add(_tmpSample);

                }

                /*Creating a New Output Well Log*/
                Template _tmp_wlvTemplate = PetrelProject.WellKnownTemplates.PetrophysicalGroup.Porosity;
                PS_SandPorosity = CreateWellLog(bh, PS_SP, _tmp_wlvTemplate);

                //Now add the Newly created samples to the Output Well Log
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_SandPorosity);
                    PS_SandPorosity.Samples = _outPutSample;
                    trans.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }
        }

        //Calculating Sand Porosity for multiple Well Logs
        public Boolean Calculate_SandPorosity_MultipleWellLog(Input input)
        {
            BoreholeCollection _bhcolObj = PS_WlRoot.BoreholeCollection;
            List<WellLogVersion> _wlVersionColl = new List<WellLogVersion>();

            _wlVersionColl.Add(input.Wlv1);
            _wlVersionColl.Add(input.Wlv2);
            _wlVersionColl.Add(input.Wlv3);
            _wlVersionColl.Add(input.Wlv4);
            _wlVersionColl.Add(input.Wlv5);

            try
            {
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_WlRoot);
                    _bhcolObj = PS_WlRoot.GetOrCreateBoreholeCollection();
                    trans.Commit();
                }

                TraverseThroughWells(_bhcolObj, _wlVersionColl, input, PS_FUNC_NO_SP);
                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }
        }


        //Calculates Organic Porosity
        public Boolean Calculate_OrganicPorosity(Borehole bh, WellLog DensityLog, double ReservoirTop, double ReservoirBottom, Boolean ReservoirTopGiven, Boolean ReservoirBottomGiven, double StartDepthOfNonkerogenShale, double EndDepthOfNonKerogenShale, float AssumedMatrixDensity, float AssumedKerogenDensity, String OutputName)
        {
            float _DensityOfNonKerogenShale;  //Non Kerogen Shale Density at the DepthOfNonKerogenShale

            List<WellLogSample> _outPutSample = new List<WellLogSample>(); //WellLog Sample Container for the Output Log
            int _indexRT = 0, _indexRB = 0;

            if (!IsUniformSingleWell(DensityLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven))
            {
                return false;
            }

            //Setting the Output Name 
            if (OutputName.Length != 0)
            {
                PS_OP = OutputName;
            }

            //Calculate the start and End Index
            GetReservoirTopBottom(DensityLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _indexRT, ref _indexRB);

            double _dStartIndex_NonKerogenShale = DensityLog.IndexAtMD(StartDepthOfNonkerogenShale);
            double _dEndIndex_NonKerogenShale = DensityLog.IndexAtMD(EndDepthOfNonKerogenShale);

            int _StartIndex_NonKerogenShale = (int)Math.Round(_dStartIndex_NonKerogenShale);
            int _EndIndex_NonKerogenShale = (int)Math.Round(_dEndIndex_NonKerogenShale);

            
            float _tmpSum = 0;
            int _tmpcount = _EndIndex_NonKerogenShale - _StartIndex_NonKerogenShale + 1; //No. of entry for AvgDensityOfNonKerogenShale Calculation

            try
            {
                for (int i = _StartIndex_NonKerogenShale; i <= _EndIndex_NonKerogenShale; i++)
                {
                    _tmpSum = _tmpSum + DensityLog[i].Value;
                }

                //Avg DensityOfNonKerogen
                _DensityOfNonKerogenShale = _tmpSum / _tmpcount;

                for (int i = _indexRT; i <= _indexRB; i++)
                {
                    double _tmpMD = DensityLog[i].MD;
                    float _tmvValue;

                    //Calculating Normalizedf Poisson Ratio and Young Modulas
                    _tmvValue = (DensityLog[i].Value - _DensityOfNonKerogenShale) / (AssumedKerogenDensity - AssumedMatrixDensity); ;
                    WellLogSample _tmpSample = new WellLogSample(_tmpMD, _tmvValue);
                    _outPutSample.Add(_tmpSample);

                }

                /*Creating a New Output Well Log*/
                Template _tmp_wlvTemplate = PetrelProject.WellKnownTemplates.PetrophysicalGroup.Porosity;
                PS_OrganicPorosity = CreateWellLog(bh, PS_OP, _tmp_wlvTemplate);

                //Now add the Newly created samples to the Output Well Log
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_OrganicPorosity);
                    PS_OrganicPorosity.Samples = _outPutSample;
                    trans.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }
        }

        //Calculating Organic Porosity for multiple Well Logs
        public Boolean Calculate_OrganicPorosity_MultipleWellLog(Input input)
        {
            BoreholeCollection _bhcolObj = PS_WlRoot.BoreholeCollection;
            List<WellLogVersion> _wlVersionColl = new List<WellLogVersion>();

            _wlVersionColl.Add(input.Wlv1);

            try
            {
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_WlRoot);
                    _bhcolObj = PS_WlRoot.GetOrCreateBoreholeCollection();
                    trans.Commit();
                }

                TraverseThroughWells(_bhcolObj, _wlVersionColl, input, PS_FUNC_NO_OP);
                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }
        }


        //Calculates Young Modulus
        public Boolean Calculate_YoungModulas(Borehole bh, WellLog PWaveSonicLog, WellLog SWaveSonicLog, WellLog DensityLog, double ReservoirTop, double ReservoirBottom, Boolean ReservoirTopGiven, Boolean ReservoirBottomGiven, String OutputName)
        {
            List<WellLogSample> _outPutSample = new List<WellLogSample>(); //WellLog Sample Container for the Output Log
            int _iPWaveRT = 0, _iPWaveRB = 0, _iSWaveRT = 0, _iSWaveRB = 0, _iDensityRT = 0, _iDensityRB = 0;

            //Check Well Logs Uniformity
            if (!IsUniformAmong3(PWaveSonicLog, SWaveSonicLog, DensityLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven))
            {
                return false;
            }

            //Setting the Output Name 
            if (OutputName.Length != 0)
            {
                PS_YM = OutputName;
            }

            //Calculate the start and End Index
            GetReservoirTopBottom(PWaveSonicLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iPWaveRT, ref _iPWaveRB);
            GetReservoirTopBottom(SWaveSonicLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iSWaveRT, ref _iSWaveRB);
            GetReservoirTopBottom(DensityLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iDensityRT, ref _iDensityRB);

            try
            {
                for (int i = _iPWaveRT, j = _iSWaveRT, k = _iDensityRT; j <= _iSWaveRB; i++, j++, k++)
                {
                    double _tmpMD = SWaveSonicLog[j].MD;
                    float _tmvValue;

                    _tmvValue = (float)(1.34 * Math.Pow(10, 10) * (DensityLog[k].Value / SWaveSonicLog[j].Value) * (3 * Math.Pow(SWaveSonicLog[j].Value, 2) - 4 * Math.Pow(PWaveSonicLog[i].Value, 2)) / (Math.Pow(SWaveSonicLog[j].Value, 2.0) - Math.Pow(PWaveSonicLog[i].Value, 2)));
                    WellLogSample _tmpSample = new WellLogSample(_tmpMD, _tmvValue);
                    _outPutSample.Add(_tmpSample);

                }

                /*Creating a New Output Well Log*/
                Template _tmp_wlvTemplate = PetrelProject.WellKnownTemplates.GeophysicalGroup.ModulusCompressional;
                PS_YoungModulas = CreateWellLog(bh, PS_YM, _tmp_wlvTemplate);

                //Now add the Newly created samples to the Output Well Log
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_YoungModulas);
                    PS_YoungModulas.Samples = _outPutSample;
                    trans.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }
        }

        //Calculating Young Modulas for multiple Well Logs
        public Boolean Calculate_YoungModulas_MultipleWellLog(Input input)
        {
            BoreholeCollection _bhcolObj = PS_WlRoot.BoreholeCollection;
            List<WellLogVersion> _wlVersionColl = new List<WellLogVersion>();

            _wlVersionColl.Add(input.Wlv1);
            _wlVersionColl.Add(input.Wlv2);
            _wlVersionColl.Add(input.Wlv3);

            try
            {
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_WlRoot);
                    _bhcolObj = PS_WlRoot.GetOrCreateBoreholeCollection();
                    trans.Commit();
                }

                TraverseThroughWells(_bhcolObj, _wlVersionColl, input, PS_FUNC_NO_YM);
                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }
        }


        //Calculates Poisson's Ratio
        public Boolean Calculate_PoissonRatio(Borehole bh, WellLog PWaveSonicLog, WellLog SWaveSonicLog, double ReservoirTop, double ReservoirBottom, Boolean ReservoirTopGiven, Boolean ReservoirBottomGiven, String OutputName)
        {
            List<WellLogSample> _outPutSample = new List<WellLogSample>(); //WellLog Sample Container for the Output Log
            int _iSWavwRT = 0, _iSWaveRB = 0, _iPWaveRT = 0, _iPWaveRB = 0;

            //Check Well Logs Uniformity
            if (!IsUniformBetween2(PWaveSonicLog, SWaveSonicLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven))
            {
                return false;
            }

            //Setting the Output Name 
            if (OutputName.Length != 0)
            {
                PS_PR = OutputName;
            }

            //Calculate the start and End Index
            GetReservoirTopBottom(SWaveSonicLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iSWavwRT, ref _iSWaveRB);
            GetReservoirTopBottom(PWaveSonicLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iPWaveRT, ref _iPWaveRB);
            try
            {
                for (int i = _iSWavwRT, j = _iPWaveRT; i <= _iSWaveRB; i++, j++)
                {
                    double _tmpMD = SWaveSonicLog[i].MD;
                    float _tmvValue;

                    _tmvValue = ((SWaveSonicLog[i].Value * SWaveSonicLog[i].Value) - 2 * (PWaveSonicLog[j].Value * PWaveSonicLog[j].Value)) / (2 * ((SWaveSonicLog[i].Value * SWaveSonicLog[i].Value) - (PWaveSonicLog[j].Value * PWaveSonicLog[j].Value)));
                    WellLogSample _tmpSample = new WellLogSample(_tmpMD, _tmvValue);
                    _outPutSample.Add(_tmpSample);

                }

                /*Creating a New Output Well Log*/
                Template _tmp_wlvTemplate = PetrelProject.WellKnownTemplates.GeophysicalGroup.PoissonRatio;
                PS_PoissonRatio = CreateWellLog(bh, PS_PR, _tmp_wlvTemplate);

                //Now add the Newly created samples to the Output Well Log
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_PoissonRatio);
                    PS_PoissonRatio.Samples = _outPutSample;
                    trans.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }


        }

        //Calculating Poisson Ratio for multiple Well Logs
        public Boolean Calculate_PoissonRatio_MultipleWellLog(Input input)
        {
            BoreholeCollection _bhcolObj = PS_WlRoot.BoreholeCollection;
            List<WellLogVersion> _wlVersionColl = new List<WellLogVersion>();

            _wlVersionColl.Add(input.Wlv1);
            _wlVersionColl.Add(input.Wlv2);

            try
            {
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_WlRoot);
                    _bhcolObj = PS_WlRoot.GetOrCreateBoreholeCollection();
                    trans.Commit();
                }

                TraverseThroughWells(_bhcolObj, _wlVersionColl, input, PS_FUNC_NO_PR);
                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }
        }


        //Calculates Brittleness Index
        public Boolean Calculate_BrittlenessIndex(Borehole bh, WellLog PoissonRatio, WellLog YoungModulas, double ReservoirTop, double ReservoirBottom, Boolean ReservoirTopGiven, Boolean ReservoirBottomGiven, String OutputName)
        {
            List<WellLogSample> _outPutSample = new List<WellLogSample>(); //WellLog Sample Container for the Output Log
            int _iPRRT = 0, _iPRRB = 0, _iYMRT = 0, _iYMRB = 0;

            //Check Well Logs Uniformity
            if (!IsUniformBetween2(PoissonRatio, YoungModulas, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven))
            {
                return false;
            }

            //Setting the Output Name 
            if (OutputName.Length != 0)
            {
                PS_BI = OutputName;
            }

            //Calculate the start and End Index
            GetReservoirTopBottom(PoissonRatio, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iPRRT, ref _iPRRB);
            GetReservoirTopBottom(YoungModulas, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iYMRT, ref _iYMRB);



            float _NormalizedPoissonRatio, _NormalizedYoungModulas, _MaxPoissonRatio = -9999, _MinPoissonRatio = 9999, _MaxYoungModulas = -9999, _MinYoungModulas = 9999;

            //Calculating Max and Min value of Poisson Ratio and Young Modulas
            try
            {
                for (int i = _iPRRT, j = _iYMRT; i <= _iPRRB; i++, j++)
                {
                    if (PoissonRatio[i].Value > _MaxPoissonRatio)
                    {
                        _MaxPoissonRatio = PoissonRatio[i].Value;
                    }

                    if (PoissonRatio[i].Value < _MinPoissonRatio)
                    {
                        _MinPoissonRatio = PoissonRatio[i].Value;
                    }

                    if (YoungModulas[j].Value > _MaxYoungModulas)
                    {
                        _MaxYoungModulas = YoungModulas[j].Value;
                    }

                    if (YoungModulas[j].Value < _MinYoungModulas)
                    {
                        _MinYoungModulas = YoungModulas[j].Value;
                    }
                }

                for (int i = _iPRRT, j = _iYMRT; i <= _iPRRB; i++, j++)
                {
                    double _tmpMD = PoissonRatio[i].MD;
                    float _tmvValue;

                    //Calculating Normalizedf Poisson Ratio and Young Modulas
                    _NormalizedPoissonRatio = 100 * (PoissonRatio[i].Value - _MaxPoissonRatio) / (_MinYoungModulas - _MaxYoungModulas);
                    _NormalizedYoungModulas = 100 * (YoungModulas[j].Value - _MaxYoungModulas) / (_MaxYoungModulas - _MinYoungModulas);

                    _tmvValue = (_NormalizedPoissonRatio + _NormalizedYoungModulas) / 2;
                    WellLogSample _tmpSample = new WellLogSample(_tmpMD, _tmvValue);
                    _outPutSample.Add(_tmpSample);

                }

                /*Creating a New Output Well Log*/
                //Confused About Template Type, Make the Well Template General I
                Template _tmp_wlvTemplate = PetrelProject.WellKnownTemplates.MiscellaneousGroup.General;
                PS_BrittlenessIndex = CreateWellLog(bh, PS_BI, _tmp_wlvTemplate);

                //Now add the Newly created samples to the Output Well Log
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_BrittlenessIndex);
                    PS_BrittlenessIndex.Samples = _outPutSample;
                    trans.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }
        }

        //Calculating BrittlenessIndex for multiple Well Logs
        public Boolean Calculate_BrittlenessIndex_MultipleWellLog(Input input)
        {
            BoreholeCollection _bhcolObj = PS_WlRoot.BoreholeCollection;
            List<WellLogVersion> _wlVersionColl = new List<WellLogVersion>();

            _wlVersionColl.Add(input.Wlv1);
            _wlVersionColl.Add(input.Wlv2);

            try
            {
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_WlRoot);
                    _bhcolObj = PS_WlRoot.GetOrCreateBoreholeCollection();
                    trans.Commit();
                }

                TraverseThroughWells(_bhcolObj, _wlVersionColl, input, PS_FUNC_NO_BI);
                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }
        }


        //Calculating Young Modulas And Poisson Ratio Using Annie Model
        public Boolean Calculate_PoissonRatio_YoungModulas_AnnieModel(Borehole bh, WellLog PWaveSonicLogVertical, WellLog SWaveSonicLogVertical, WellLog SWaveSonicLogHorizontal, WellLog DensityLog, WellLog VerticalStressLog, WellLog PorePressureLog, double ReservoirTop, double ReservoirBottom, Boolean ReservoirTopGiven, Boolean ReservoirBottomGiven, float BiotConstant, float PoreElasticConstant, float MinHorizontalStrain, float MaxHorizontalStrain, List<String> OutputName)
        {
            List<WellLogSample> _C33Sample = new List<WellLogSample>(); //WellLog Sample Container for the C33 Output Log
            List<WellLogSample> _C44Sample = new List<WellLogSample>(); //WellLog Sample Container for the C44 Output Log
            List<WellLogSample> _C66Sample = new List<WellLogSample>(); //WellLog Sample Container for the C66 Output Log
            List<WellLogSample> _C13Sample = new List<WellLogSample>(); //WellLog Sample Container for the C13 Output Log
            List<WellLogSample> _C11Sample = new List<WellLogSample>(); //WellLog Sample Container for the C11 Output Log

            List<WellLogSample> _PoissonHorizontalSample = new List<WellLogSample>(); //WellLog Sample Container for the Horizontal Poisson Output Log
            List<WellLogSample> _PoissonVerticalSample = new List<WellLogSample>(); //WellLog Sample Container for the Vertical Poisson Output Log

            List<WellLogSample> _YoungModulasHorizontalSample = new List<WellLogSample>(); //WellLog Sample Container for the Horizontal Young Modulas Output Log
            List<WellLogSample> _YoungModulasVerticalSample = new List<WellLogSample>(); //WellLog Sample Container for the Vertical Poisson Output Log

            List<WellLogSample> _MinHorStressSample = new List<WellLogSample>();        //WellLog Sample Container for Min Hor Stress


            int _iPWaveVerRT = 0, _iPWaveVerRB = 0, _iSWaveVerRT = 0, _iSWaveVerRB = 0, _iSWaveHorRT = 0, _iSWaveHorRB = 0, _iDenRT = 0, _iDenRB = 0, _iVSRT = 0, _iVSRB = 0, _iPPRT = 0, _iPPRB = 0;

            //Check Well Logs Uniformity
            List<WellLog> _tmpWellLogColl = new List<WellLog>();
            _tmpWellLogColl.Add(PWaveSonicLogVertical);
            _tmpWellLogColl.Add(SWaveSonicLogVertical);
            _tmpWellLogColl.Add(SWaveSonicLogHorizontal);
            _tmpWellLogColl.Add(DensityLog);
            _tmpWellLogColl.Add(VerticalStressLog);
            _tmpWellLogColl.Add(PorePressureLog);

            if (!IsUniform(_tmpWellLogColl, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven))
            {
                return false;
            }

            //Setting the Output Name 
            if (OutputName[0].Length != 0)
            {
                PS_YMH = OutputName[0];
            }
            if (OutputName[1].Length != 0)
            {
                PS_YMV = OutputName[1];
            }
            if (OutputName[2].Length != 0)
            {
                PS_PRH = OutputName[2];
            }
            if (OutputName[3].Length != 0)
            {
                PS_PRV = OutputName[3];
            }
            if (OutputName[4].Length != 0)
            {
                PS_MHS = OutputName[4];
            }
            //Calculate the start and End Index
            GetReservoirTopBottom(PWaveSonicLogVertical, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iPWaveVerRT, ref _iPWaveVerRB);
            GetReservoirTopBottom(SWaveSonicLogVertical, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iSWaveVerRT, ref _iSWaveVerRB);
            GetReservoirTopBottom(SWaveSonicLogHorizontal, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iSWaveHorRT, ref _iSWaveHorRB);
            GetReservoirTopBottom(DensityLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iDenRT, ref _iDenRB);
            GetReservoirTopBottom(VerticalStressLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iVSRT, ref _iVSRB);
            GetReservoirTopBottom(PorePressureLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iPPRT, ref _iPPRB);

            try
            {
                for (int i = _iPWaveVerRT, j = _iSWaveVerRT, k = _iSWaveHorRT, l = _iDenRT, m = _iVSRT, n = _iPPRT; i <= _iPWaveVerRB; i++, j++, k++, l++, m++, n++)
                {
                    double _tmpMD = PWaveSonicLogVertical[i].MD;

                    float _tmpC33Value;
                    float _tmpC44Value;
                    float _tmpC66Value;
                    float _tmpC13Value;
                    float _tmpC11Value;

                    float _tmpPoissonVerticalValue;
                    float _tmpPoissonHorizontalValue;

                    float _tmpYoungModulasVerticalValue;
                    float _tmpYoungModulasHorizontalValue;

                    float _tmpMinHorStressValue;

                    _tmpC33Value = (float)((DensityLog[l].Value / Math.Pow(PWaveSonicLogVertical[i].Value, 2)));
                    WellLogSample _tmpC33Sample = new WellLogSample(_tmpMD, _tmpC33Value);
                    _C33Sample.Add(_tmpC33Sample);


                    _tmpC44Value = (float)(DensityLog[l].Value / Math.Pow(SWaveSonicLogVertical[j].Value, 2));
                    WellLogSample _tmpC44Sample = new WellLogSample(_tmpMD, _tmpC44Value);
                    _C44Sample.Add(_tmpC44Sample);


                    _tmpC66Value = (float)(DensityLog[l].Value / Math.Pow(SWaveSonicLogHorizontal[k].Value, 2));
                    WellLogSample _tmp66Sample = new WellLogSample(_tmpMD, _tmpC66Value);
                    _C66Sample.Add(_tmp66Sample);


                    _tmpC13Value = _tmpC33Value - 2 * _tmpC44Value;
                    WellLogSample _tmpC13Sample = new WellLogSample(_tmpMD, _tmpC13Value);
                    _C13Sample.Add(_tmpC13Sample);


                    _tmpC11Value = 2 * _tmpC66Value + _tmpC13Value;
                    WellLogSample _tmpC11Sample = new WellLogSample(_tmpMD, _tmpC11Value);
                    _C11Sample.Add(_tmpC11Sample);


                    _tmpPoissonVerticalValue = _tmpC13Value / (_tmpC11Value + _tmpC13Value);
                    WellLogSample _tmpPVS = new WellLogSample(_tmpMD, _tmpPoissonVerticalValue);
                    _PoissonVerticalSample.Add(_tmpPVS);


                    _tmpPoissonHorizontalValue = (float)(((_tmpC33Value * _tmpC13Value) - Math.Pow(_tmpC13Value, 2)) / ((_tmpC33Value * _tmpC11Value) - (Math.Pow(_tmpC13Value, 2))));
                    WellLogSample _tmpPHS = new WellLogSample(_tmpMD, _tmpPoissonHorizontalValue);
                    _PoissonHorizontalSample.Add(_tmpPHS);


                    _tmpYoungModulasVerticalValue = _tmpC33Value - (float)((2 * Math.Pow(_tmpC13Value, 2)) / (_tmpC11Value + _tmpC13Value));
                    WellLogSample _tmpYMVS = new WellLogSample(_tmpMD, _tmpYoungModulasVerticalValue);
                    _YoungModulasVerticalSample.Add(_tmpYMVS);



                    _tmpYoungModulasHorizontalValue = (float)(_tmpC11Value + ((Math.Pow(_tmpC13Value, 2) * ((2 * _tmpC13Value) - _tmpC11Value - _tmpC33Value)) / ((_tmpC33Value * _tmpC11Value) - (Math.Pow(_tmpC13Value, 2)))));
                    WellLogSample _tmpYMHS = new WellLogSample(_tmpMD, _tmpYoungModulasHorizontalValue);
                    _YoungModulasHorizontalSample.Add(_tmpYMHS);

                    _tmpMinHorStressValue = (float)((((_tmpYoungModulasHorizontalValue * _tmpPoissonVerticalValue) / (_tmpYoungModulasVerticalValue * (1 - _tmpPoissonHorizontalValue))) * (VerticalStressLog[m].Value - (BiotConstant * (1 - PoreElasticConstant) * PorePressureLog[n].Value))) + (BiotConstant * PorePressureLog[n].Value) + ((_tmpYoungModulasHorizontalValue / (1 - Math.Pow(_tmpPoissonHorizontalValue, 2))) * MinHorizontalStrain) + (((_tmpYoungModulasHorizontalValue * _tmpPoissonHorizontalValue) / (1 - Math.Pow(_tmpPoissonHorizontalValue, 2))) * MaxHorizontalStrain));
                    WellLogSample _tmpMHSS = new WellLogSample(_tmpMD, _tmpMinHorStressValue);
                    _MinHorStressSample.Add(_tmpMHSS);

                }

                /*Creating a New Output Well Log*/
                Template _tmp_wlvTemplate_C33 = PetrelProject.WellKnownTemplates.GeophysicalGroup.ModulusCompressional;
                Template _tmp_wlvTemplate_C44 = PetrelProject.WellKnownTemplates.GeophysicalGroup.ShearModulus;
                Template _tmp_wlvTemplate_C66 = PetrelProject.WellKnownTemplates.GeophysicalGroup.ShearModulus;
                Template _tmp_wlvTemplate_C13 = PetrelProject.WellKnownTemplates.GeophysicalGroup.ShearModulus;
                Template _tmp_wlvTemplate_C11 = PetrelProject.WellKnownTemplates.GeophysicalGroup.ModulusCompressional;

                Template _tmp_wlvTemplate_PRH = PetrelProject.WellKnownTemplates.GeophysicalGroup.PoissonRatio;
                Template _tmp_wlvTemplate_PRV = PetrelProject.WellKnownTemplates.GeophysicalGroup.PoissonRatio;


                Template _tmp_wlvTemplate_YMH = PetrelProject.WellKnownTemplates.GeophysicalGroup.ModulusCompressional;
                Template _tmp_wlvTemplate_YMV = PetrelProject.WellKnownTemplates.GeophysicalGroup.ModulusCompressional;

                Template _tmp_wlvTemplate_MHS = PetrelProject.WellKnownTemplates.GeophysicalGroup.ShearModulus;
                //PS_YoungModulas = CreateWellLog(bh, PS_YM, _tmp_wlvTemplate);

                PS_C33WellLog = CreateWellLog(bh, PS_C33, _tmp_wlvTemplate_C33);
                PS_C44WellLog = CreateWellLog(bh, PS_C44, _tmp_wlvTemplate_C44);
                PS_C66WellLog = CreateWellLog(bh, PS_C66, _tmp_wlvTemplate_C66);
                PS_C13WellLog = CreateWellLog(bh, PS_C13, _tmp_wlvTemplate_C13);
                PS_C11WellLog = CreateWellLog(bh, PS_C11, _tmp_wlvTemplate_C11);

                PS_YoungModulasHorizontal = CreateWellLog(bh, PS_YMH, _tmp_wlvTemplate_YMH);
                PS_YoungModulasVertical = CreateWellLog(bh, PS_YMV, _tmp_wlvTemplate_YMV);

                PS_PoissonRatioHorizontal = CreateWellLog(bh, PS_PRH, _tmp_wlvTemplate_PRH);
                PS_PoissonRatioVertical = CreateWellLog(bh, PS_PRV, _tmp_wlvTemplate_PRV);

                PS_MinHorStress = CreateWellLog(bh, PS_MHS, _tmp_wlvTemplate_MHS);
                //Now add the Newly created samples to the Output Well Log
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_C33WellLog);
                    PS_C33WellLog.Samples = _C33Sample;
                    trans.Commit();
                }
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_C44WellLog);
                    PS_C44WellLog.Samples = _C44Sample;
                    trans.Commit();
                }
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_C66WellLog);
                    PS_C66WellLog.Samples = _C66Sample;
                    trans.Commit();
                }
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_C13WellLog);
                    PS_C13WellLog.Samples = _C13Sample;
                    trans.Commit();
                }
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_C11WellLog);
                    PS_C11WellLog.Samples = _C11Sample;
                    trans.Commit();
                }
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_PoissonRatioHorizontal);
                    PS_PoissonRatioHorizontal.Samples = _PoissonHorizontalSample;
                    trans.Commit();
                }
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_PoissonRatioVertical);
                    PS_PoissonRatioVertical.Samples = _PoissonVerticalSample;
                    trans.Commit();
                }
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_YoungModulasHorizontal);
                    PS_YoungModulasHorizontal.Samples = _YoungModulasHorizontalSample;
                    trans.Commit();
                }
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_YoungModulasVertical);
                    PS_YoungModulasVertical.Samples = _YoungModulasVerticalSample;
                    trans.Commit();
                }
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_MinHorStress);
                    PS_MinHorStress.Samples = _MinHorStressSample;
                    trans.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }

        }

        //Calculating PoissonRatio_YoungModulas using AnnieModel for multiple Well Logs
        public Boolean Calculate_PoissonRatio_YoungModulas_AnnieModel_MultipleWellLog(Input input)
        {
            BoreholeCollection _bhcolObj = PS_WlRoot.BoreholeCollection;
            List<WellLogVersion> _wlVersionColl = new List<WellLogVersion>();

            _wlVersionColl.Add(input.Wlv1);
            _wlVersionColl.Add(input.Wlv2);
            _wlVersionColl.Add(input.Wlv3);
            _wlVersionColl.Add(input.Wlv4);
            _wlVersionColl.Add(input.Wlv5);
            _wlVersionColl.Add(input.Wlv6);

            try
            {
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_WlRoot);
                    _bhcolObj = PS_WlRoot.GetOrCreateBoreholeCollection();
                    trans.Commit();
                }

                TraverseThroughWells(_bhcolObj, _wlVersionColl, input, PS_FUNC_NO_AM);
                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }
        }


        //Calculating Young Modulas And Poisson Ratio Using Annie Model
        public Boolean Calculate_PoissonRatio_YoungModulas_Modified_AnnieModel(Borehole bh, WellLog PWaveSonicLogVertical, WellLog SWaveSonicLogVertical, WellLog SWaveSonicLogHorizontal, WellLog DensityLog, WellLog VerticalStressLog, WellLog PorePressureLog, double ReservoirTop, double ReservoirBottom, Boolean ReservoirTopGiven, Boolean ReservoirBottomGiven, float Constant1, float Constant2, float BiotConstant, float PoreElasticConstant, float MinHorizontalStrain, float MaxHorizontalStrain, List<String> OutputName)
        {
            List<WellLogSample> _C33Sample = new List<WellLogSample>(); //WellLog Sample Container for the C33 Output Log
            List<WellLogSample> _C44Sample = new List<WellLogSample>(); //WellLog Sample Container for the C44 Output Log
            List<WellLogSample> _C66Sample = new List<WellLogSample>(); //WellLog Sample Container for the C66 Output Log
            List<WellLogSample> _C13Sample = new List<WellLogSample>(); //WellLog Sample Container for the C13 Output Log
            List<WellLogSample> _C12Sample = new List<WellLogSample>(); //WellLog Sample Container for the C12 Output Log
            List<WellLogSample> _C11Sample = new List<WellLogSample>(); //WellLog Sample Container for the C11 Output Log

            List<WellLogSample> _PoissonHorizontalSample = new List<WellLogSample>(); //WellLog Sample Container for the Horizontal Poisson Output Log
            List<WellLogSample> _PoissonVerticalSample = new List<WellLogSample>(); //WellLog Sample Container for the Vertical Poisson Output Log

            List<WellLogSample> _YoungModulasHorizontalSample = new List<WellLogSample>(); //WellLog Sample Container for the Horizontal Young Modulas Output Log
            List<WellLogSample> _YoungModulasVerticalSample = new List<WellLogSample>(); //WellLog Sample Container for the Vertical Poisson Output Log

            List<WellLogSample> _MinHorStressSample = new List<WellLogSample>();        //WellLog Sample Container for Min Hor Stress

            int _iPWaveVerRT = 0, _iPWaveVerRB = 0, _iSWaveVerRT = 0, _iSWaveVerRB = 0, _iSWaveHorRT = 0, _iSWaveHorRB = 0, _iDenRT = 0, _iDenRB = 0, _iVSRT = 0, _iVSRB = 0, _iPPRT = 0, _iPPRB = 0;

            //Check Well Logs Uniformity
            List<WellLog> _tmpWellLogColl = new List<WellLog>();
            _tmpWellLogColl.Add(PWaveSonicLogVertical);
            _tmpWellLogColl.Add(SWaveSonicLogVertical);
            _tmpWellLogColl.Add(SWaveSonicLogHorizontal);
            _tmpWellLogColl.Add(DensityLog);
            _tmpWellLogColl.Add(VerticalStressLog);
            _tmpWellLogColl.Add(PorePressureLog);

            if (!IsUniform(_tmpWellLogColl, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven))
            {
                return false;
            }

            //Setting the Output Name 
            if (OutputName[0].Length != 0)
            {
                PS_YMH = OutputName[0];
            }
            if (OutputName[1].Length != 0)
            {
                PS_YMV = OutputName[1];
            }
            if (OutputName[2].Length != 0)
            {
                PS_PRH = OutputName[2];
            }
            if (OutputName[3].Length != 0)
            {
                PS_PRV = OutputName[3];
            }
            if (OutputName[4].Length != 0)
            {
                PS_MHS = OutputName[4];
            }

            //Calculate the start and End Index
            GetReservoirTopBottom(PWaveSonicLogVertical, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iPWaveVerRT, ref _iPWaveVerRB);
            GetReservoirTopBottom(SWaveSonicLogVertical, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iSWaveVerRT, ref _iSWaveVerRB);
            GetReservoirTopBottom(SWaveSonicLogHorizontal, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iSWaveHorRT, ref _iSWaveHorRB);
            GetReservoirTopBottom(DensityLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iDenRT, ref _iDenRB);
            GetReservoirTopBottom(VerticalStressLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iVSRT, ref _iVSRB);
            GetReservoirTopBottom(PorePressureLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iPPRT, ref _iPPRB);
            try
            {
                for (int i = _iPWaveVerRT, j = _iSWaveVerRT, k = _iSWaveHorRT, l = _iDenRT, m = _iVSRT, n = _iPPRT; i <= _iPWaveVerRB; i++, j++, k++, l++, m++, n++)
                {
                    double _tmpMD = PWaveSonicLogVertical[i].MD;

                    float _tmpC33Value;
                    float _tmpC44Value;
                    float _tmpC66Value;
                    float _tmpC13Value;
                    float _tmpC12Value;
                    float _tmpC11Value;

                    float _tmpPoissonVerticalValue;
                    float _tmpPoissonHorizontalValue;

                    float _tmpYoungModulasVerticalValue;
                    float _tmpYoungModulasHorizontalValue;

                    float _tmpMinHorStressValue;

                    _tmpC33Value = (float)(DensityLog[l].Value / Math.Pow(PWaveSonicLogVertical[i].Value, 2));
                    WellLogSample _tmpC33Sample = new WellLogSample(_tmpMD, _tmpC33Value);
                    _C33Sample.Add(_tmpC33Sample);


                    _tmpC44Value = (float)(DensityLog[l].Value / Math.Pow(SWaveSonicLogVertical[j].Value, 2));
                    WellLogSample _tmpC44Sample = new WellLogSample(_tmpMD, _tmpC44Value);
                    _C44Sample.Add(_tmpC44Sample);

                    _tmpC66Value = (float)(DensityLog[l].Value / Math.Pow(SWaveSonicLogHorizontal[k].Value, 2));
                    WellLogSample _tmp66Sample = new WellLogSample(_tmpMD, _tmpC66Value);
                    _C66Sample.Add(_tmp66Sample);

                    _tmpC11Value = Constant1 * (2 * (_tmpC66Value - _tmpC44Value) + _tmpC33Value);
                    WellLogSample _tmpC11Sample = new WellLogSample(_tmpMD, _tmpC11Value);
                    _C11Sample.Add(_tmpC11Sample);

                    _tmpC12Value = _tmpC11Value - 2 * _tmpC66Value;
                    WellLogSample _tmpC12Sample = new WellLogSample(_tmpMD, _tmpC12Value);
                    _C12Sample.Add(_tmpC12Sample);

                    _tmpC13Value = Constant2 * _tmpC12Value;
                    WellLogSample _tmpC13Sample = new WellLogSample(_tmpMD, _tmpC13Value);
                    _C13Sample.Add(_tmpC13Sample);

                    _tmpPoissonVerticalValue = _tmpC13Value / (_tmpC11Value + _tmpC12Value);
                    WellLogSample _tmpPVS = new WellLogSample(_tmpMD, _tmpPoissonVerticalValue);
                    _PoissonVerticalSample.Add(_tmpPVS);

                    _tmpPoissonHorizontalValue = (float)(((_tmpC33Value * _tmpC12Value) - Math.Pow(_tmpC13Value, 2)) / ((_tmpC33Value * _tmpC11Value) - (Math.Pow(_tmpC13Value, 2))));
                    WellLogSample _tmpPHS = new WellLogSample(_tmpMD, _tmpPoissonHorizontalValue);
                    _PoissonHorizontalSample.Add(_tmpPHS);

                    _tmpYoungModulasVerticalValue = _tmpC33Value - (float)((2 * Math.Pow(_tmpC13Value, 2)) / (_tmpC11Value + _tmpC12Value));
                    WellLogSample _tmpYMVS = new WellLogSample(_tmpMD, _tmpYoungModulasVerticalValue);
                    _YoungModulasVerticalSample.Add(_tmpYMVS);

                    _tmpYoungModulasHorizontalValue = (float)(_tmpC11Value + (((Math.Pow(_tmpC13Value, 2) * (_tmpC13Value - _tmpC11Value)) + (_tmpC12Value * (Math.Pow(_tmpC13Value, 2) - (_tmpC12Value * _tmpC33Value)))) / ((_tmpC33Value * _tmpC11Value) - (Math.Pow(_tmpC13Value, 2)))));
                    WellLogSample _tmpYMHS = new WellLogSample(_tmpMD, _tmpYoungModulasHorizontalValue);
                    _YoungModulasHorizontalSample.Add(_tmpYMHS);

                    _tmpMinHorStressValue = (float)((((_tmpYoungModulasHorizontalValue * _tmpPoissonVerticalValue) / (_tmpYoungModulasVerticalValue * (1 - _tmpPoissonHorizontalValue))) * (VerticalStressLog[m].Value - (BiotConstant * (1 - PoreElasticConstant) * PorePressureLog[n].Value))) + (BiotConstant * PorePressureLog[n].Value) + ((_tmpYoungModulasHorizontalValue / (1 - Math.Pow(_tmpPoissonHorizontalValue, 2))) * MinHorizontalStrain) + (((_tmpYoungModulasHorizontalValue * _tmpPoissonHorizontalValue) / (1 - Math.Pow(_tmpPoissonHorizontalValue, 2))) * MaxHorizontalStrain));
                    WellLogSample _tmpMHSS = new WellLogSample(_tmpMD, _tmpMinHorStressValue);
                    _MinHorStressSample.Add(_tmpMHSS);
                }

                /*Creating a New Output Well Log*/
                Template _tmp_wlvTemplate_C33 = PetrelProject.WellKnownTemplates.GeophysicalGroup.ModulusCompressional;
                Template _tmp_wlvTemplate_C44 = PetrelProject.WellKnownTemplates.GeophysicalGroup.ShearModulus;
                Template _tmp_wlvTemplate_C66 = PetrelProject.WellKnownTemplates.GeophysicalGroup.ShearModulus;
                Template _tmp_wlvTemplate_C13 = PetrelProject.WellKnownTemplates.GeophysicalGroup.ShearModulus;
                Template _tmp_wlvTemplate_C12 = PetrelProject.WellKnownTemplates.GeophysicalGroup.ShearModulus;
                Template _tmp_wlvTemplate_C11 = PetrelProject.WellKnownTemplates.GeophysicalGroup.ModulusCompressional;

                Template _tmp_wlvTemplate_PRH = PetrelProject.WellKnownTemplates.GeophysicalGroup.PoissonRatio;
                Template _tmp_wlvTemplate_PRV = PetrelProject.WellKnownTemplates.GeophysicalGroup.PoissonRatio;


                Template _tmp_wlvTemplate_YMH = PetrelProject.WellKnownTemplates.GeophysicalGroup.ModulusCompressional;
                Template _tmp_wlvTemplate_YMV = PetrelProject.WellKnownTemplates.GeophysicalGroup.ModulusCompressional;

                Template _tmp_wlvTemplate_MHS = PetrelProject.WellKnownTemplates.GeophysicalGroup.ShearModulus;
                //PS_YoungModulas = CreateWellLog(bh, PS_YM, _tmp_wlvTemplate);

                PS_C33WellLog = CreateWellLog(bh, PS_C33, _tmp_wlvTemplate_C33);
                PS_C44WellLog = CreateWellLog(bh, PS_C44, _tmp_wlvTemplate_C44);
                PS_C66WellLog = CreateWellLog(bh, PS_C66, _tmp_wlvTemplate_C66);
                PS_C13WellLog = CreateWellLog(bh, PS_C13, _tmp_wlvTemplate_C13);
                PS_C12WellLog = CreateWellLog(bh, PS_C12, _tmp_wlvTemplate_C12);
                PS_C11WellLog = CreateWellLog(bh, PS_C11, _tmp_wlvTemplate_C11);

                PS_YoungModulasHorizontal = CreateWellLog(bh, PS_YMH, _tmp_wlvTemplate_YMH);
                PS_YoungModulasVertical = CreateWellLog(bh, PS_YMV, _tmp_wlvTemplate_YMV);

                PS_PoissonRatioHorizontal = CreateWellLog(bh, PS_PRH, _tmp_wlvTemplate_PRH);
                PS_PoissonRatioVertical = CreateWellLog(bh, PS_PRV, _tmp_wlvTemplate_PRV);

                PS_MinHorStress = CreateWellLog(bh, PS_MHS, _tmp_wlvTemplate_MHS);
                //Now add the Newly created samples to the Output Well Log
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_C33WellLog);
                    PS_C33WellLog.Samples = _C33Sample;
                    trans.Commit();
                }
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_C44WellLog);
                    PS_C44WellLog.Samples = _C44Sample;
                    trans.Commit();
                }
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_C66WellLog);
                    PS_C66WellLog.Samples = _C66Sample;
                    trans.Commit();
                }
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_C13WellLog);
                    PS_C13WellLog.Samples = _C13Sample;
                    trans.Commit();
                }
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_C12WellLog);
                    PS_C12WellLog.Samples = _C12Sample;
                    trans.Commit();
                }
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_C11WellLog);
                    PS_C11WellLog.Samples = _C11Sample;
                    trans.Commit();
                }
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_PoissonRatioHorizontal);
                    PS_PoissonRatioHorizontal.Samples = _PoissonHorizontalSample;
                    trans.Commit();
                }
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_PoissonRatioVertical);
                    PS_PoissonRatioVertical.Samples = _PoissonVerticalSample;
                    trans.Commit();
                }
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_YoungModulasHorizontal);
                    PS_YoungModulasHorizontal.Samples = _PoissonHorizontalSample;
                    trans.Commit();
                }
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_YoungModulasVertical);
                    PS_YoungModulasVertical.Samples = _PoissonVerticalSample;
                    trans.Commit();
                }
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_MinHorStress);
                    PS_MinHorStress.Samples = _MinHorStressSample;
                    trans.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }

        }

        //Calculating PoissonRatio_YoungModulas using Modified_AnnieModel for multiple Well Logs
        public Boolean Calculate_PoissonRatio_YoungModulas_Modified_AnnieModel_MultipleWellLog(Input input)
        {
            BoreholeCollection _bhcolObj = PS_WlRoot.BoreholeCollection;
            List<WellLogVersion> _wlVersionColl = new List<WellLogVersion>();

            _wlVersionColl.Add(input.Wlv1);
            _wlVersionColl.Add(input.Wlv2);
            _wlVersionColl.Add(input.Wlv3);
            _wlVersionColl.Add(input.Wlv4);
            _wlVersionColl.Add(input.Wlv5);
            _wlVersionColl.Add(input.Wlv6);

            try
            {
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_WlRoot);
                    _bhcolObj = PS_WlRoot.GetOrCreateBoreholeCollection();
                    trans.Commit();
                }

                TraverseThroughWells(_bhcolObj, _wlVersionColl, input, PS_FUNC_NO_MAM);
                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }
        }


        //Calculating Epsilon Using VTI Model
        public Boolean Calculate_Epsilon(Borehole bh, WellLog C11Log, WellLog C33Log, double ReservoirTop, double ReservoirBottom, Boolean ReservoirTopGiven, Boolean ReservoirBottomGiven, String OutputName)
        {
            List<WellLogSample> _outPutSample = new List<WellLogSample>(); //WellLog Sample Container for the Output Log

            int _iC11RT = 0, _iC11RB = 0, _iC33RT = 0, _iC33RB = 0;

            //Check Well Logs Uniformity
            if (!IsUniformBetween2(C11Log, C33Log, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven))
            {
                return false;
            }

            //Setting the Output Name 
            if (OutputName.Length != 0)
            {
                PS_E = OutputName;
            }

            //Calculate the start and End Index
            GetReservoirTopBottom(C11Log, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iC11RT, ref _iC11RB);
            GetReservoirTopBottom(C33Log, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iC33RT, ref _iC33RB);

            try
            {
                for (int i = _iC11RT, j = _iC33RT; i <= _iC11RB; i++, j++)
                {
                    double _tmpMD = C11Log[i].MD;
                    float _tmvValue;

                    //Calculating Normalizedf Poisson Ratio and Young Modulas                    
                    _tmvValue = (C11Log[i].Value - C33Log[j].Value) / (2 * C33Log[j].Value);
                    WellLogSample _tmpSample = new WellLogSample(_tmpMD, _tmvValue);
                    _outPutSample.Add(_tmpSample);

                }

                /*Creating a New Output Well Log*/
                //Confused About Template Type, Percent Should be OK
                Template _tmp_wlvTemplate = PetrelProject.WellKnownTemplates.MiscellaneousGroup.Percent;
                PS_Epsilon = CreateWellLog(bh, PS_E, _tmp_wlvTemplate);

                //Now add the Newly created samples to the Output Well Log
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_Epsilon);
                    PS_Epsilon.Samples = _outPutSample;
                    trans.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }
        }

        //Calculating Epsilon Using VTI Model for multiple Well Logs
        public Boolean Calculate_Epsilon_MultipleWellLog(Input input)
        {
            BoreholeCollection _bhcolObj = PS_WlRoot.BoreholeCollection;
            List<WellLogVersion> _wlVersionColl = new List<WellLogVersion>();

            _wlVersionColl.Add(input.Wlv1);
            _wlVersionColl.Add(input.Wlv2);

            try
            {
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_WlRoot);
                    _bhcolObj = PS_WlRoot.GetOrCreateBoreholeCollection();
                    trans.Commit();
                }

                TraverseThroughWells(_bhcolObj, _wlVersionColl, input, PS_FUNC_NO_E);
                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }
        }


        //Calculating Gamma Using VTI model
        public Boolean Calculate_Gamma(Borehole bh, WellLog C66Log, WellLog C44Log, double ReservoirTop, double ReservoirBottom, Boolean ReservoirTopGiven, Boolean ReservoirBottomGiven, String OutputName)
        {
            List<WellLogSample> _outPutSample = new List<WellLogSample>(); //WellLog Sample Container for the Output Log

            int _iC66RT = 0, _iC66RB = 0, _iC44RT = 0, _iC44RB = 0;

            //Check Well Logs Uniformity
            if (!IsUniformBetween2(C66Log, C44Log, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven))
            {
                return false;
            }

            //Setting the Output Name 
            if (OutputName.Length != 0)
            {
                PS_G = OutputName;
            }

            //Calculate the start and End Index
            GetReservoirTopBottom(C66Log, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iC66RT, ref _iC66RB);
            GetReservoirTopBottom(C44Log, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iC44RT, ref _iC44RB);

            try
            {
                for (int i = _iC66RT, j = _iC44RT; i <= _iC66RB; i++, j++)
                {
                    double _tmpMD = C66Log[i].MD;
                    float _tmvValue;

                    //Calculating Normalizedf Poisson Ratio and Young Modulas                    
                    _tmvValue = (C66Log[i].Value - C44Log[i].Value) / (2 * C44Log[i].Value);
                    WellLogSample _tmpSample = new WellLogSample(_tmpMD, _tmvValue);
                    _outPutSample.Add(_tmpSample);

                }

                /*Creating a New Output Well Log*/
                //Confused About Template Type, Percent Should be OK
                Template _tmp_wlvTemplate = PetrelProject.WellKnownTemplates.MiscellaneousGroup.Percent;
                PS_Gamma = CreateWellLog(bh, PS_G, _tmp_wlvTemplate);

                //Now add the Newly created samples to the Output Well Log
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_Gamma);
                    PS_Gamma.Samples = _outPutSample;
                    trans.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }
        }

        //Calculating Gamma for multiple Well Logs
        public Boolean Calculate_Gamma_MultipleWellLog(Input input)
        {
            BoreholeCollection _bhcolObj = PS_WlRoot.BoreholeCollection;
            List<WellLogVersion> _wlVersionColl = new List<WellLogVersion>();

            _wlVersionColl.Add(input.Wlv1);
            _wlVersionColl.Add(input.Wlv2);

            try
            {
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_WlRoot);
                    _bhcolObj = PS_WlRoot.GetOrCreateBoreholeCollection();
                    trans.Commit();
                }

                TraverseThroughWells(_bhcolObj, _wlVersionColl, input, PS_FUNC_NO_G);
                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }
        }


        //Calulates Azimuth Anisotropy
        public Boolean Calculate_AzimuthalAnisotropy(Borehole bh, WellLog DipoleSonicFast, WellLog DipoleSonicSlow, double ReservoirTop, double ReservoirBottom, Boolean ReservoirTopGiven, Boolean ReservoirBottomGiven, String OutputName)
        {
            List<WellLogSample> _outPutSample = new List<WellLogSample>(); //WellLog Sample Container for the Output Log

            int _iFastRT = 0, _iFastRB = 0, _iSlowRT = 0, _iSlowRB = 0;

            //Check Well Logs Uniformity
            if (!IsUniformBetween2(DipoleSonicFast, DipoleSonicSlow, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven))
            {
                return false;
            }

            //Setting the Output Name 
            if (OutputName.Length != 0)
            {
                PS_AA = OutputName;
            }


            //Calculate the start and End Index
            GetReservoirTopBottom(DipoleSonicFast, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iFastRT, ref _iFastRB);
            GetReservoirTopBottom(DipoleSonicSlow, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iSlowRT, ref _iSlowRB);

            try
            {
                for (int i = _iFastRT, j = _iSlowRT; i <= _iFastRB; i++, j++)
                {
                    double _tmpMD = DipoleSonicFast[i].MD;
                    float _tmvValue;

                    //Calculating Normalizedf Poisson Ratio and Young Modulas                    
                    _tmvValue = (DipoleSonicFast[i].Value - DipoleSonicSlow[j].Value) / (DipoleSonicSlow[j].Value);
                    WellLogSample _tmpSample = new WellLogSample(_tmpMD, _tmvValue);
                    _outPutSample.Add(_tmpSample);

                }

                /*Creating a New Output Well Log*/
                //Confused About Template Type, Percent Should ne OK
                Template _tmp_wlvTemplate = PetrelProject.WellKnownTemplates.MiscellaneousGroup.Percent;
                PS_AzimuthalAnisotropy = CreateWellLog(bh, PS_AA, _tmp_wlvTemplate);

                //Now add the Newly created samples to the Output Well Log
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_AzimuthalAnisotropy);
                    PS_AzimuthalAnisotropy.Samples = _outPutSample;
                    trans.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }
        }

        //Calculating Azimuth Anisotropy for multiple Well Logs
        public Boolean Calculate_AzimuthalAnisotropy_MultipleWellLog(Input input)
        {
            BoreholeCollection _bhcolObj = PS_WlRoot.BoreholeCollection;
            List<WellLogVersion> _wlVersionColl = new List<WellLogVersion>();

            _wlVersionColl.Add(input.Wlv1);
            _wlVersionColl.Add(input.Wlv2);

            try
            {
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_WlRoot);
                    _bhcolObj = PS_WlRoot.GetOrCreateBoreholeCollection();
                    trans.Commit();
                }

                TraverseThroughWells(_bhcolObj, _wlVersionColl, input, PS_FUNC_NO_AA);
                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }
        }

        //Calculates Vertical Stress 
        public Boolean Calculate_VerticalStress(Borehole bh, WellLog DensityLog, double ReservoirTop, double ReservoirBottom, Boolean ReservoirTopGiven, Boolean ReservoirBottomGiven, double WaterDepth, String OutputName)
        {
            List<WellLogSample> _outPutSample = new List<WellLogSample>(); //WellLog Sample Container for the Output Log
            int _indexRT = 0, _indexRB = 0;

            if (!IsUniformSingleWell(DensityLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven))
            {
                return false;
            }

            //Setting the Output Name 
            if (OutputName.Length != 0)
            {
                PS_VS = OutputName;
            }

            //Calculate the start and End Index
            GetReservoirTopBottom(DensityLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _indexRT, ref _indexRB);

            try
            {

                for (int i = _indexRT; i <= _indexRB; i++)
                {
                    double _tmpMD = DensityLog[i].MD;
                    float _tmvValue;
                    float _avgTopToDepth = 0, _tmpSum = 0;

                    for (int j = _indexRT; j <= i; j++)
                    {
                        _tmpSum += DensityLog[j].Value;
                    }
                    _avgTopToDepth = _tmpSum / (i - _indexRT + 1);

                    
                    //Calculating Vertical Stress
                    _tmvValue = (float)(_avgTopToDepth * PS_g * (DensityLog[i].MD - WaterDepth) + PS_WaterDensity * PS_g * WaterDepth);

                    
                    WellLogSample _tmpSample = new WellLogSample(_tmpMD, _tmvValue);
                    _outPutSample.Add(_tmpSample);

                }

                /*Creating a New Output Well Log*/
                Template _tmp_wlvTemplate = PetrelProject.WellKnownTemplates.GeophysicalGroup.ShearModulus;
                PS_VerticalStress = CreateWellLog(bh, PS_VS, _tmp_wlvTemplate);

                //Now add the Newly created samples to the Output Well Log
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_VerticalStress);
                    PS_VerticalStress.Samples = _outPutSample;
                    trans.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }

        }

        //Calculating Vertical Stress for multiple Well Logs
        public Boolean Calculate_VerticalStress_MultipleWellLog(Input input)
        {
            BoreholeCollection _bhcolObj = PS_WlRoot.BoreholeCollection;
            List<WellLogVersion> _wlVersionColl = new List<WellLogVersion>();

            _wlVersionColl.Add(input.Wlv1);

            try
            {
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_WlRoot);
                    _bhcolObj = PS_WlRoot.GetOrCreateBoreholeCollection();
                    trans.Commit();
                }

                TraverseThroughWells(_bhcolObj, _wlVersionColl, input, PS_FUNC_NO_VS);
                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }
        }


        //Calculating Isotropic Min Horizontal Stress
        public Boolean Calculate_MinHorStress_Isotropic(Borehole bh, WellLog PoissonRatioLog, WellLog YoungModulasLog, WellLog VerticalStressLog, WellLog PorePressureLog, double ReservoirTop, double ReservoirBottom, Boolean ReservoirTopGiven, Boolean ReservoirBottomGiven, float BiotConstant, float MinHorStrain, float MaxHorStrain, String OutputName)
        {
            List<WellLogSample> _outPutSample = new List<WellLogSample>();

            List<WellLog> _tmpWellLogColl = new List<WellLog>();
            _tmpWellLogColl.Add(PoissonRatioLog);
            _tmpWellLogColl.Add(YoungModulasLog);
            _tmpWellLogColl.Add(VerticalStressLog);
            _tmpWellLogColl.Add(PorePressureLog);
            if (!IsUniform(_tmpWellLogColl, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven))
            {
                return false;
            }

            //Setting the Output Name 
            if (OutputName.Length != 0)
            {
                PS_MHS = OutputName;
            }

            int _iPRRT = 0, _iPRRB = 0, _iYMRT = 0, _iYMRB = 0, _iVSRT = 0, _iVSRB = 0, _iPPRT = 0, _iPPRB = 0;         //Effective Start and End index for Calculation

            GetReservoirTopBottom(PoissonRatioLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iPRRT, ref _iPRRB);
            GetReservoirTopBottom(YoungModulasLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iYMRT, ref _iYMRB);
            GetReservoirTopBottom(VerticalStressLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iVSRT, ref _iVSRB);
            GetReservoirTopBottom(PorePressureLog, ReservoirTop, ReservoirBottom, ReservoirTopGiven, ReservoirBottomGiven, ref _iPPRT, ref _iPPRB);

            try
            {
                for (int i = _iPRRT, j = _iYMRT, k = _iVSRT, l = _iPPRT; i <= _iPRRB; i++, j++, k++, l++)
                {
                    double _tmpMD = PoissonRatioLog[i].MD;
                    float _tmvValue;

                    //Calculating Normalizedf Poisson Ratio and Young Modulas                    
                    _tmvValue = (float)((((PoissonRatioLog[i].Value) / (1 - PoissonRatioLog[i].Value)) * (VerticalStressLog[k].Value - (BiotConstant * PorePressureLog[l].Value))) + (BiotConstant * PorePressureLog[l].Value) + (((YoungModulasLog[j].Value) / (1 - Math.Pow(PoissonRatioLog[i].Value, 2))) * MinHorStrain) + (((YoungModulasLog[j].Value * PoissonRatioLog[i].Value) / (1 - Math.Pow(PoissonRatioLog[i].Value, 2))) * MaxHorStrain));
                    WellLogSample _tmpSample = new WellLogSample(_tmpMD, _tmvValue);
                    _outPutSample.Add(_tmpSample);

                }

                /*Creating a New Output Well Log*/
                //Confused About Template Type, Percent Should ne OK
                Template _tmp_wlvTemplate = PetrelProject.WellKnownTemplates.GeophysicalGroup.ShearModulus;

                PS_AzimuthalAnisotropy = CreateWellLog(bh, PS_MHS, _tmp_wlvTemplate);

                //Now add the Newly created samples to the Output Well Log
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_MinHorStress);
                    PS_MinHorStress.Samples = _outPutSample;
                    trans.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }

        }

        //Calculating Isotropic Min Horizontal Stress for multiple Well Logs
        public Boolean Calculate_MinHorStress_Isotropic_MultipleWellLog(Input input)
        {
            BoreholeCollection _bhcolObj = PS_WlRoot.BoreholeCollection;
            List<WellLogVersion> _wlVersionColl = new List<WellLogVersion>();

            _wlVersionColl.Add(input.Wlv1);
            _wlVersionColl.Add(input.Wlv2);
            _wlVersionColl.Add(input.Wlv3);
            _wlVersionColl.Add(input.Wlv4);

            try
            {
                using (ITransaction trans = DataManager.NewTransaction())
                {
                    trans.Lock(PS_WlRoot);
                    _bhcolObj = PS_WlRoot.GetOrCreateBoreholeCollection();
                    trans.Commit();
                }

                TraverseThroughWells(_bhcolObj, _wlVersionColl, input, PS_FUNC_NO_MHS);
                return true;
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return false;
                throw;
            }
        }


        /***************************************************************/

    }
}