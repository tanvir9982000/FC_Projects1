using System;
using System.Drawing;
using System.Windows.Forms;

using Slb.Ocean.Core;
using Slb.Ocean.Petrel;
using Slb.Ocean.Petrel.UI;
using Slb.Ocean.Petrel.Workflow;
using Slb.Ocean.Petrel.DomainObject;
using Slb.Ocean.Petrel.DomainObject.Well;

namespace FracScope
{
    /// <summary>
    /// This class is the user interface which forms the focus for the capabilities offered by the process.  
    /// This often includes UI to set up arguments and interactively run a batch part expressed as a workstep.
    /// </summary>
    partial class FracScopeUI : UserControl
    {
        private FracScope workstep;
        Input input = new Input();
        /// <summary>
        /// The argument package instance being edited by the UI.
        /// </summary>
        private FracScope.Arguments args;
        /// <summary>
        /// Contains the actual underlaying context.
        /// </summary>
        private WorkflowContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="FracScopeUI"/> class.
        /// </summary>
        /// <param name="workstep">the workstep instance</param>
        /// <param name="args">the arguments</param>
        /// <param name="context">the underlying context in which this UI is being used</param>
        
        
        
        public FracScopeUI(FracScope workstep, FracScope.Arguments args, WorkflowContext context)
        {
            InitializeComponent();

            this.workstep = workstep;
            this.args = args;
            this.context = context;
            this.groups_Invisible();
            this.BlankGB.Visible = false;
            this.tabControl1.Visible = true;
            this.tabControlGPInOut.Visible = true;


        }

        private void groups_Invisible()
        {
            this.BlankGB.Visible = false;
            this.AzimuthalAnisotropyGB.Visible = false;
            this.BrittlenessIndexGB.Visible = false;
            this.ClayPorosityGB.Visible = false;
            this.DensityPorosityGB.Visible = false;
            this.FracturePorosityGB.Visible = false;
            this.EpsilonGB.Visible = false;
            this.GammaGB.Visible = false;
            this.MinHorStress_GB.Visible = false;
            this.OrganicPorosityGB.Visible = false;
            this.PoissonRatioGB.Visible = false;
            this.PRYMAM_GB.Visible = false;
            this.PRYM2_GB.Visible = false;            
            this.SandPorosityGB.Visible = false;
            this.TotalOrganicPorosityGB.Visible = false;
            this.TOC2_GB.Visible = false;
            this.VerticalStress_GB.Visible = false;
            this.YoungModulusGB.Visible = false;
            this.VolumeOfShaleGB.Visible = false;
            this.tpGEOutputPRYM_GB.Visible = false;
            this.tpGEOutputGB.Visible = false;
            
        }
        
        private void Form_Clear()
        {
            //VSH
            this.VSHtextBox2.Clear();
            this.VSHtextBox3.Clear();
            this.VSHtextBox4.Clear();
            this.VSHtextBox5.Clear();
            this.VSHtextBox6.Clear();
            this.VSHcheckBox1.Checked = false;
            this.VSHcheckBox2.Checked = false;

            //YM
            this.YMtextBox2.Clear();
            this.YMtextBox3.Clear();
            this.YMtextBox4.Clear();
            this.YMtextBox5.Clear();
            this.YMtextBox6.Clear();
            this.YMcheckBox1.Checked = false;
            this.YMcheckBox2.Checked = false;

            //CP
            this.CPtextBox2.Clear();
            this.CPtextBox3.Clear();
            this.CPtextBox4.Clear();
            this.CPtextBox5.Clear();
            this.CPcheckBox1.Checked = false;
            this.CPcheckBox2.Checked = false;

            //PR
            this.PRtextBox2.Clear();
            this.PRtextBox3.Clear();
            this.PRtextBox4.Clear();
            this.PRtextBox5.Clear();
            this.PRcheckBox1.Checked = false;
            this.PRcheckBox2.Checked = false;



            //TOC
            this.TOPtextBox3.Clear();
            this.TOPtextBox4.Clear();
            this.TOPtextBox5.Clear();
            this.TOPtextBox6.Clear();
            this.TOPtextBox7.Clear();
            this.TOPtextBox8.Clear();
            this.TOPtextBox9.Clear();

            this.TOP_AMD_checkBox.Checked = false;
            this.TOP_DOB_checkBox.Checked = false;
            this.TOP_RTop_checkBox.Checked = false;
            this.TOP_RBottom_checkBox.Checked = false;

            //DP
            DPtextBox2.Clear();
            DPtextBox3.Clear();
            DptextBox4.Clear();
            DPtextBox5.Clear();
            DPtextBox6.Clear();

            DP_DM_checkBox.Checked = false;
            DP_DofF_checkBox.Checked = false;
            DPcheckBox1.Checked = false;
            DPcheckBox2.Checked = false;

            //OP
            OPtextBox2.Clear();
            OPtextBox3.Clear();
            OPtextBox4.Clear();
            OPtextBox5.Clear();
            OPtextBox6.Clear();
            OPtextBox7.Clear();
            OPtextBox8.Clear();

            OP_AMD_checkBox.Checked = false;
            OPcheckBox1.Checked = false;
            OPcheckBox2.Checked = false;

            //BI
            BItextBox2.Clear();
            BItextBox3.Clear();
            BItextBox4.Clear();
            BItextBox5.Clear();

            BIcheckBox1.Checked = false;
            BIcheckBox2.Checked = false;

            //Epsilon
            EtextBox2.Clear();
            EtextBox3.Clear();
            EtextBox4.Clear();
            EtextBox5.Clear();

            EcheckBox1.Checked = false;
            EcheckBox2.Checked = false;

            //Gamma
            this.GtextBox2.Clear();
            this.GtextBox3.Clear();
            this.GtextBox4.Clear();
            this.GtextBox5.Clear();
            this.GcheckBox1.Checked = false;
            this.GcheckBox2.Checked = false;

            //AA
            AAtextBox2.Clear();
            AAtextBox3.Clear();
            AAtextBox4.Clear();
            AAtextBox5.Clear();

            AAcheckBox1.Checked = false;
            AAcheckBox2.Checked = false;

            //PRYMAM
            this.PRYMAMtextBox2.Clear();
            this.PRYMAMtextBox3.Clear();
            this.PRYMAMtextBox4.Clear();
            this.PRYMAMtextBox4.Clear();
            this.PRYMAMtextBox5.Clear();
            this.PRYMAMtextBox9.Clear();
            this.PRYMAMtextBox10.Clear();
            this.PRYMAMcheckBox9.Checked = false;
            this.PRYMAMcheckBox10.Checked = false;

            //FP
            this.FPtextBox1.Clear();
            this.FPtextBox2.Clear();
            this.FPtextBox3.Clear();
            this.FPtextBox4.Clear();
            this.FPcheckBox3.Checked=false;
            this.FPcheckBox4.Checked = false;

            //SP
            this.SPtextBox1.Clear();
            this.SPtextBox2.Clear();
            this.SPtextBox3.Clear();
            this.SPtextBox4.Clear();
            this.SPtextBox5.Clear();
            this.SPtextBox6.Clear();
            this.SPtextBox7.Clear();
            this.SPcheckBox6.Checked = false;
            this.SPcheckBox7.Checked = false;

            //TOC2
            this.TOC2textBox1.Clear();
            this.TOC2textBox2.Clear();
            this.TOC2textBox3.Clear();
            this.TOC2textBox4.Clear();
            this.TOC2checkBox3.Checked = false;
            this.TOC2checkBox4.Checked = false;

            //MHS
            this.MHStextBox1.Clear();
            this.MHStextBox2.Clear();
            this.MHStextBox3.Clear();
            this.MHStextBox4.Clear();
            this.MHStextBox5.Clear();
            this.MHStextBox6.Clear();
            this.MHStextBox7.Clear();
            this.MHStextBox8.Clear();
            this.MHStextBox9.Clear();
            this.MHScheckBox5.Checked = false;
            this.MHScheckBox6.Checked = false;
            this.MHScheckBox7.Checked = false;
            this.MHScheckBox8.Checked = false;
            this.MHScheckBox9.Checked = false;

            //PRYM2
            this.PRYM2textBox1.Clear();
            this.PRYM2textBox2.Clear();
            this.PRYM2textBox3.Clear();
            this.PRYM2textBox4.Clear();
            this.PRYM2textBox5.Clear();
            this.PRYM2textBox6.Clear();
            this.PRYM2textBox7.Clear();
            this.PRYM2textBox8.Clear();
            this.PRYM2textBox9.Clear();
            this.PRYM2textBox10.Clear();
            this.PRYM2textBox11.Clear();
            this.PRYM2textBox12.Clear();
            this.PRYM2textBox13.Clear();
            this.PRYM2textBox14.Clear();
            this.PRYM2checkBox7.Checked =false;
            this.PRYM2checkBox8.Checked = false;
            this.PRYM2checkBox9.Checked = false;
            this.PRYM2checkBox10.Checked = false;
            this.PRYM2checkBox11.Checked = false;
            this.PRYM2checkBox12.Checked = false;
            this.PRYM2checkBox13.Checked = false;
            this.PRYM2checkBox14.Checked = false;

            //VS
            this.VStextBox1.Clear();

            //tpGPOutput
            this.tpGPOutputtextBox.Clear();

            //tpGEOutput
            this.tpGEOutputtextBox.Clear();

            //tpGEOutputPRYM
            this.OutputPRYM2textBox1.Clear();
            this.OutputPRYM2textBox2.Clear();
            this.OutputPRYM2textBox3.Clear();
            this.OutputPRYM2textBox4.Clear();
            this.OutputPRYM2textBox5.Clear();




        }



        #region CP


        private void CPdropTarget2_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv1 = dropped as WellLogVersion;
                if (this.input.Wlv1 != null)
                {
                    CPtextBox2.Text = this.input.Wlv1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog1 = dropped as WellLog;
                if (this.input.WellLog1 != null)
                {
                    CPtextBox2.Text = this.input.WellLog1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void CPdropTarget3_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv2 = dropped as WellLogVersion;
                if (this.input.Wlv2 != null)
                {
                    CPtextBox3.Text = this.input.Wlv2.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog2 = dropped as WellLog;
                if (this.input.WellLog2 != null)
                {
                    CPtextBox3.Text = this.input.WellLog2.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void CPCancelbutton_Click(object sender, EventArgs e)
        {
            this.CPtextBox2.Clear();
            this.CPtextBox3.Clear();
            this.CPtextBox4.Clear();
            this.CPtextBox5.Clear();
            this.CPcheckBox1.Checked = false;
            this.CPcheckBox2.Checked = false;

        }

        private void CPCalculatebutton_Click(object sender, EventArgs e)
        {
            FracScopeModel FSM = new FracScopeModel();
            Boolean flag = true;
            //PetrelLogger.InfoBox(this.input.WellLog1.Name);

            if (this.CPtextBox2.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Volume of Shale Log is not specified");
                return;
            }
            if (this.CPtextBox3.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Density Porosity Log is not specified");
                return;
            }

            if (this.input.ReservoirTopGiven)
            {
                if (this.CPtextBox4.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Top is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirTop = FSM.PS_ConvertFromUI(Convert.ToDouble(CPtextBox4.Text));
                }
            }
            if (this.input.ReservoirBottomGiven)
            {
                if (this.CPtextBox5.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Bottom is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirBottom = FSM.PS_ConvertFromUI(Convert.ToDouble(CPtextBox5.Text));
                }
            }

            if (this.tpGPOutputtextBox.Text.Trim().Length == 0)
            {
                this.input.OutputFileName = "";
            }
            else
            {
                this.input.OutputFileName = tpGPOutputtextBox.Text;
            }

            if (flag != false)
            {
                
                Cursor.Current = Cursors.WaitCursor;
                if (!input.IsMultipleWelllog)
                {
                    this.input.Borehole = this.input.WellLog1.Borehole;
                    if (FSM.Calculate_ClayPorosity(this.input.Borehole, this.input.WellLog1, this.input.WellLog2, this.input.ReservoirTop, this.input.ReservoirBottom, this.input.ReservoirTopGiven, this.input.ReservoirBottomGiven, this.input.OutputFileName))
                    {
                        //PetrelLogger.InfoBox("Clay Porosity Was Calculated Successfully");
                    }
                    else
                    {
                        PetrelLogger.WarnBox("Sorry, Calculation Could not be completed, Please Try again");
                    }
                }
                else
                {
                    FSM.Calculate_ClayPorosity_MultipleWellLogs(this.input);
                }
                Cursor.Current = Cursors.Default;
            }

        }

        private void CPcheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CPcheckBox1.Checked)
            {
                CPtextBox4.Clear();
                CPtextBox4.Enabled = false;
                this.input.ReservoirTopGiven = false;
            }
            else
            {
                CPtextBox4.Enabled = true;
                this.input.ReservoirTopGiven = true;
            }
        }

        private void CPcheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (CPcheckBox2.Checked)
            {
                CPtextBox5.Clear();
                CPtextBox5.Enabled = false;
                this.input.ReservoirTopGiven = false;
            }
            else
            {
                CPtextBox5.Enabled = true;
                this.input.ReservoirTopGiven = true;
            }

        }

        private void CPtoolTipHotspot3_MouseHover(object sender, EventArgs e)
        {
            this.CPtoolTipPanel3.Visible = true;
        }

        private void CPtoolTipHotspot3_MouseLeave(object sender, EventArgs e)
        {
            this.CPtoolTipPanel3.Visible = false;
        }

        private void CPtoolTipHotspot4_MouseHover(object sender, EventArgs e)
        {
            this.CPtoolTipPanel4.Visible = true;
        }

        private void CPtoolTipHotspot4_MouseLeave(object sender, EventArgs e)
        {
            this.CPtoolTipPanel4.Visible = false;
        }
        #endregion

        #region DP


        private void DPdropTarget2_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv1 = dropped as WellLogVersion;
                if (this.input.Wlv1 != null)
                {
                    DPtextBox2.Text = this.input.Wlv1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog1 = dropped as WellLog;
                if (this.input.WellLog1 != null)
                {
                    DPtextBox2.Text = this.input.WellLog1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void DP_DM_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DP_DM_checkBox.Checked)
            {
                DPtextBox3.Clear();
                DPtextBox3.Enabled = false;
                this.input.DensityMatrix = (float)2710.0;  //Unit KG/m^3
            }
            else
            {
                DPtextBox3.Enabled = true;
            }
        }

        private void DP_DofF_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DP_DofF_checkBox.Checked)
            {
                DptextBox4.Clear();
                DptextBox4.Enabled = false;
                this.input.DensityOfFluid = (float)1000.0;  //Unit KG/m^3
            }
            else
            {
                DptextBox4.Enabled = true;
            }
        }

        private void DPcheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (DPcheckBox1.Checked)
            {
                DPtextBox5.Clear();
                DPtextBox5.Enabled = false;
                this.input.ReservoirTopGiven = false;
            }
            else
            {
                DPtextBox5.Enabled = true;
                this.input.ReservoirTopGiven = true;
            }
        }

        private void DPcheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (DPcheckBox2.Checked)
            {
                DPtextBox6.Clear();
                DPtextBox6.Enabled = false;
                this.input.ReservoirBottomGiven = false;
            }
            else
            {
                DPtextBox6.Enabled = true;
                this.input.ReservoirBottomGiven = true;
            }
        }

        private void DPCancelbutton_Click(object sender, EventArgs e)
        {
            DPtextBox2.Clear();
            DPtextBox3.Clear();
            DptextBox4.Clear();
            DPtextBox5.Clear();
            DPtextBox6.Clear();

            DP_DM_checkBox.Checked = false;
            DP_DofF_checkBox.Checked = false;
            DPcheckBox1.Checked = false;
            DPcheckBox2.Checked = false;
        }

        private void DPCalculatebutton_Click(object sender, EventArgs e)
        {
            FracScopeModel FSM = new FracScopeModel();
            Boolean flag = true;
            

            if (this.DPtextBox2.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Density Log is not specified");
                return;
            }

            if (!this.DP_DM_checkBox.Checked)
            {
                if (this.DPtextBox3.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Density Matrix is not specified");
                    return;
                }
                else
                {
                    this.input.DensityMatrix = (float)Convert.ToDouble(this.DPtextBox3.Text);
                }
            }
            if (!this.DP_DofF_checkBox.Checked)
            {
                if (this.DptextBox4.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Density of Fluid is not specified");
                    return;
                }
                else
                {
                    this.input.DensityOfFluid = (float)Convert.ToDouble(this.DptextBox4.Text);
                }

            }

            if (this.input.ReservoirTopGiven)
            {
                if (this.DPtextBox5.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Top is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirTop = FSM.PS_ConvertFromUI(Convert.ToDouble(DPtextBox5.Text));
                }
            }
            if (this.input.ReservoirBottomGiven)
            {
                if (this.DPtextBox6.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Bottom is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirBottom = FSM.PS_ConvertFromUI(Convert.ToDouble(DPtextBox6.Text));
                }
            }

            if (this.tpGPOutputtextBox.Text.Trim().Length == 0)
            {
                this.input.OutputFileName = "";
            }
            else
            {
                this.input.OutputFileName = tpGPOutputtextBox.Text;
            }


            if (flag != false)
            {
                try
                {
                    
                    Cursor.Current = Cursors.WaitCursor;
                    if (!this.input.IsMultipleWelllog)
                    {
                        this.input.Borehole = this.input.WellLog1.Borehole;
                        if (FSM.Calculate_DensityPorosity(this.input.Borehole, this.input.WellLog1, this.input.ReservoirTop, this.input.ReservoirBottom, this.input.ReservoirTopGiven, this.input.ReservoirBottomGiven, this.input.DensityMatrix, this.input.DensityOfFluid, this.input.OutputFileName))
                        {
                            ///PetrelLogger.InfoBox("Density Porosity Was Calculated Successfully");
                        }
                        else
                        {
                            PetrelLogger.WarnBox("Sorry, Calculation Could not be completed, Please Try again");
                        }
                    }
                    else
                    {
                        FSM.Calculate_DensityPorosity_MultipleWellLogs(this.input);
                    }
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {

                    PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                    return ;
                    throw;
                }
            }
        }
        
        private void DPtoolTipHotspot1_MouseHover(object sender, EventArgs e)
        {
            this.DPtoolTipPanel1.Visible = true;
        }

        private void DPtoolTipHotspot1_MouseLeave(object sender, EventArgs e)
        {
            this.DPtoolTipPanel1.Visible = false;
        }

        private void DPtoolTipHotspot2_MouseHover(object sender, EventArgs e)
        {
            this.DPtoolTipPanel2.Visible = true;
        }

        private void DPtoolTipHotspot2_MouseLeave(object sender, EventArgs e)
        {
            this.DPtoolTipPanel2.Visible = false;
        }

        private void DPtoolTipHotspot3_MouseHover(object sender, EventArgs e)
        {
            this.DPtoolTipPanel3.Visible = true;
        }

        private void DPtoolTipHotspot3_MouseLeave(object sender, EventArgs e)
        {
            this.DPtoolTipPanel3.Visible = false;
        }

        private void DPtoolTipHotspot4_MouseHover(object sender, EventArgs e)
        {
            this.DPtoolTipPanel4.Visible = true;
        }

        private void DPtoolTipHotspot4_MouseLeave(object sender, EventArgs e)
        {
            this.DPtoolTipPanel4.Visible = false;
        }


        #endregion

        #region FP

        private void FPdropTarget1_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv1 = dropped as WellLogVersion;
                if (this.input.Wlv1 != null)
                {
                    FPtextBox1.Text = this.input.Wlv1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog1 = dropped as WellLog;
                if (this.input.WellLog1 != null)
                {
                    FPtextBox1.Text = this.input.WellLog1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void FPcheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.FPcheckBox3.Checked)
            {
                this.FPtextBox3.Clear();
                FPtextBox3.Enabled = false;
                this.input.ReservoirTopGiven = false;
            }
            else
            {
                FPtextBox3.Enabled = true;
                this.input.ReservoirTopGiven = true;
            }
        }
        private void FPcheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (this.FPcheckBox4.Checked)
            {
                this.FPtextBox4.Clear();
                FPtextBox4.Enabled = false;
                this.input.ReservoirBottomGiven = false;
            }
            else
            {
                FPtextBox4.Enabled = true;
                this.input.ReservoirTopGiven = true;
            }

        }

        private void FPCancelbutton_Click(object sender, EventArgs e)
        {
            this.FPtextBox1.Clear();
            this.FPtextBox2.Clear();
            this.FPtextBox3.Clear();
            this.FPtextBox4.Clear();

            this.FPcheckBox3.Checked = false;
            this.FPcheckBox4.Checked = false;
        }

        private void FPCalculatebutton_Click(object sender, EventArgs e)
        {
            FracScopeModel FSM = new FracScopeModel();
            Boolean flag = true;

            if(this.FPtextBox1.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Fracture Density Log is not Specified");
            }

            if (this.FPtextBox2.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.InfoBox("Emperical Constant is not provided");
            }

            if (this.input.ReservoirTopGiven)
            {
                if (this.FPtextBox3.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Top is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirTop = FSM.PS_ConvertFromUI(Convert.ToDouble(this.FPtextBox3.Text));
                }
            }
            if (this.input.ReservoirBottomGiven)
            {
                if (this.FPtextBox4.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Bottom is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirBottom = FSM.PS_ConvertFromUI(Convert.ToDouble(FPtextBox4.Text));
                }
            }

            if (this.tpGPOutputtextBox.Text.Trim().Length == 0)
            {
                this.input.OutputFileName = "";
            }
            else
            {
                this.input.OutputFileName = tpGPOutputtextBox.Text;
            }

            if (flag != false)
            {
                
                Cursor.Current = Cursors.WaitCursor;
                if (!input.IsMultipleWelllog)
                {
                    this.input.Borehole = this.input.WellLog1.Borehole;
                    if (FSM.Calculate_FracturePorosity(this.input.Borehole, this.input.WellLog1, this.input.ReservoirTop, this.input.ReservoirBottom, this.input.ReservoirTopGiven, this.input.ReservoirBottomGiven, this.input.Constant, this.input.OutputFileName))
                    {
                        //PetrelLogger.InfoBox("Clay Porosity Was Calculated Successfully");
                    }
                    else
                    {
                        PetrelLogger.WarnBox("Sorry, Calculation Could not be completed, Please Try again");
                    }
                }
                else
                {
                    FSM.Calculate_FracturePorosity_MultipleWellLogs(this.input);
                }
                Cursor.Current = Cursors.Default;
            }

        }

        private void FPtoolTipHotspot1_MouseHover(object sender, EventArgs e)
        {
            this.FPtoolTipPanel1.Visible = true;
        }

        private void FPtoolTipHotspot1_MouseLeave(object sender, EventArgs e)
        {
            this.FPtoolTipPanel1.Visible = false;
        }

        private void FPtoolTipHotspot2_MouseHover(object sender, EventArgs e)
        {
            this.FPtoolTipPanel2.Visible = true;
        }

        private void FPtoolTipHotspot2_MouseLeave(object sender, EventArgs e)
        {
            this.FPtoolTipPanel2.Visible = false;
        }

        private void FPtoolTipHotspot3_MouseHover(object sender, EventArgs e)
        {
            this.FPtoolTipPanel3.Visible = true;
        }

        private void FPtoolTipHotspot3_MouseLeave(object sender, EventArgs e)
        {
            this.FPtoolTipPanel3.Visible = false;
        }
        private void FPtoolTipHotspot4_MouseHover(object sender, EventArgs e)
        {
            this.FPtoolTipPanel4.Visible = true;
        }

        private void FPtoolTipHotspot4_MouseLeave(object sender, EventArgs e)
        {
            this.FPtoolTipPanel4.Visible = false;
        }

        #endregion

        #region OP


        private void OPdropTarget2_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv1 = dropped as WellLogVersion;
                if (this.input.Wlv1 != null)
                {
                    OPtextBox2.Text = this.input.Wlv1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog1 = dropped as WellLog;
                if (this.input.WellLog1 != null)
                {
                    OPtextBox2.Text = this.input.WellLog1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void OP_AMD_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (OP_AMD_checkBox.Checked)
            {
                OPtextBox5.Clear();
                OPtextBox5.Enabled = false;

                this.input.AssumedMatrixDensity = (float)2710.0;  //Unit Kg/m^3
            }
            else
            {
                OPtextBox5.Enabled = true;
            }
        }

        private void OPcheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (OPcheckBox1.Checked)
            {
                OPtextBox7.Clear();
                OPtextBox7.Enabled = false;
                this.input.ReservoirTopGiven = false;
            }
            else
            {
                OPtextBox7.Enabled = true;
                this.input.ReservoirTopGiven = true;
            }
        }

        private void OPcheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (OPcheckBox2.Checked)
            {
                OPtextBox8.Clear();
                OPtextBox8.Enabled = false;
                this.input.ReservoirBottomGiven = false;
            }
            else
            {
                OPtextBox8.Enabled = true;
                this.input.ReservoirBottomGiven = true;
            }
        }

        private void OPCancelbutton_Click(object sender, EventArgs e)
        {
            OPtextBox2.Clear();
            OPtextBox3.Clear();
            OPtextBox4.Clear();
            OPtextBox5.Clear();
            OPtextBox6.Clear();
            OPtextBox7.Clear();
            OPtextBox8.Clear();

            OP_AMD_checkBox.Checked = false;
            OPcheckBox1.Checked = false;
            OPcheckBox2.Checked = false;
        }

        private void OPCalculatebutton_Click(object sender, EventArgs e)
        {
            FracScopeModel FSM = new FracScopeModel();
            Boolean flag = true;
            //PetrelLogger.InfoBox(this.input.WellLog1.Name);

            if (this.OPtextBox2.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Density Log is not specified");
                return;
            }
            if (this.OPtextBox3.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Start Depth of non Kerogen Shale is not specified");
                return;
            }
            if (this.OPtextBox4.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("End Depth of non Kerogen Shale is not specified");
                return;
            }
            if (!this.OP_AMD_checkBox.Checked)
            {
                if (this.OPtextBox5.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Assumed Matrix Density is not specified");
                    return;
                }
                else
                {
                    this.input.AssumedMatrixDensity = (float)Convert.ToDouble(this.OPtextBox5.Text);
                }
            }

            if (this.OPtextBox6.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Assumed Kerogen Density is not given");
                return;
            }
            else
            {
                this.input.AssumedKerogenDensity = (float)Convert.ToDouble(this.OPtextBox6.Text);
            }


            if (this.input.ReservoirTopGiven)
            {
                if (this.OPtextBox7.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Top is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirTop = FSM.PS_ConvertFromUI(Convert.ToDouble(OPtextBox7.Text));
                }
            }
            if (this.input.ReservoirBottomGiven)
            {
                if (this.OPtextBox8.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Bottom is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirBottom = FSM.PS_ConvertFromUI(Convert.ToDouble(OPtextBox8.Text));
                }
            }

            if (this.tpGPOutputtextBox.Text.Trim().Length == 0)
            {
                this.input.OutputFileName = "";
            }
            else
            {
                this.input.OutputFileName = tpGPOutputtextBox.Text;
            }

            
            if (flag != false)
            {
                
                Cursor.Current = Cursors.WaitCursor;
                if (!this.input.IsMultipleWelllog)
                {
                    this.input.Borehole = this.input.WellLog1.Borehole;
                    if (FSM.Calculate_OrganicPorosity(this.input.Borehole, this.input.WellLog1, this.input.ReservoirTop, this.input.ReservoirBottom, this.input.ReservoirTopGiven, this.input.ReservoirBottomGiven, this.input.StartDepthOfNonkerogenShale, this.input.EndDepthOfNonKerogenShale, this.input.AssumedMatrixDensity, this.input.AssumedKerogenDensity, this.input.OutputFileName))
                    {
                        //PetrelLogger.InfoBox("Organic Porosity Was Calculated Successfully");
                    }
                    else
                    {
                        PetrelLogger.WarnBox("Sorry, Calculation Could not be completed, Please Try again");
                    }
                }
                else
                {
                    FSM.Calculate_OrganicPorosity_MultipleWellLog(this.input);
                }
                Cursor.Current = Cursors.Default;
            }
            
        }

        private void OPtoolTipHotspot1_MouseHover(object sender, EventArgs e)
        {
            this.OPtoolTipPanel1.Visible = true;
        }

        private void OPtoolTipHotspot1_MouseLeave(object sender, EventArgs e)
        {
            this.OPtoolTipPanel1.Visible = false;
        }

        private void OPtoolTipHotspot2_MouseHover(object sender, EventArgs e)
        {
            this.OPtoolTipPanel2.Visible = true;
        }

        private void OPtoolTipHotspot2_MouseLeave(object sender, EventArgs e)
        {
            this.OPtoolTipPanel2.Visible = false;
        }

        private void OPtoolTipHotspot3_MouseHover(object sender, EventArgs e)
        {
            this.OPtoolTipPanel3.Visible = true;
        }

        private void OPtoolTipHotspot3_MouseLeave(object sender, EventArgs e)
        {
            this.OPtoolTipPanel3.Visible = false;
        }

        private void OPtoolTipHotspot4_MouseHover(object sender, EventArgs e)
        {
            this.OPtoolTipPanel5.Visible = true;
        }

        private void OPtoolTipHotspot4_MouseLeave(object sender, EventArgs e)
        {
            this.OPtoolTipPanel5.Visible = false;
        }

        private void OPtoolTipHotspot5_MouseHover(object sender, EventArgs e)
        {
            this.OPtoolTipPanel4.Visible = true;
        }

        private void OPtoolTipHotspot5_MouseLeave(object sender, EventArgs e)
        {
            this.OPtoolTipPanel4.Visible = false;
        }

        private void OPtoolTipHotspot6_MouseHover(object sender, EventArgs e)
        {
            this.OPtoolTipPanel6.Visible = true;
        }

        private void OPtoolTipHotspot6_MouseLeave(object sender, EventArgs e)
        {
            this.OPtoolTipPanel6.Visible = false;
        }

        #endregion

        #region SP

        private void SPdropTarget1_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv1 = dropped as WellLogVersion;
                if (this.input.Wlv1 != null)
                {
                    SPtextBox1.Text = this.input.Wlv1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog1 = dropped as WellLog;
                if (this.input.WellLog1 != null)
                {
                    SPtextBox1.Text = this.input.WellLog1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void SPdropTarget2_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv2 = dropped as WellLogVersion;
                if (this.input.Wlv2 != null)
                {
                    SPtextBox2.Text = this.input.Wlv2.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog2 = dropped as WellLog;
                if (this.input.WellLog2 != null)
                {
                    SPtextBox2.Text = this.input.WellLog2.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void SPdropTarget3_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv3 = dropped as WellLogVersion;
                if (this.input.Wlv3 != null)
                {
                    SPtextBox3.Text = this.input.Wlv3.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog3 = dropped as WellLog;
                if (this.input.WellLog3 != null)
                {
                    SPtextBox3.Text = this.input.WellLog3.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void SPdropTarget4_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv4 = dropped as WellLogVersion;
                if (this.input.Wlv4 != null)
                {
                    SPtextBox4.Text = this.input.Wlv4.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog4 = dropped as WellLog;
                if (this.input.WellLog4 != null)
                {
                    SPtextBox4.Text = this.input.WellLog4.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void SPdropTarget5_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv5 = dropped as WellLogVersion;
                if (this.input.Wlv5 != null)
                {
                    SPtextBox5.Text = this.input.Wlv5.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog5 = dropped as WellLog;
                if (this.input.WellLog5 != null)
                {
                    SPtextBox5.Text = this.input.WellLog5.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void SPcheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (this.SPcheckBox6.Checked)
            {
                this.SPtextBox6.Clear();
                SPtextBox6.Enabled = false;
                this.input.ReservoirTopGiven = false;
            }
            else
            {
                SPtextBox6.Enabled = true;
                this.input.ReservoirTopGiven = true;
            }

        }

        private void SPcheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (this.SPcheckBox7.Checked)
            {
                this.SPtextBox7.Clear();
                SPtextBox7.Enabled = false;
                this.input.ReservoirTopGiven = false;
            }
            else
            {
                SPtextBox7.Enabled = true;
                this.input.ReservoirBottomGiven = true;
            }
        }

        private void SPCancelbutton_Click(object sender, EventArgs e)
        {
            this.SPtextBox1.Clear();
            this.SPtextBox2.Clear();
            this.SPtextBox3.Clear();
            this.SPtextBox4.Clear();
            this.SPtextBox5.Clear();
            this.SPtextBox6.Clear();
            this.SPtextBox7.Clear();

            this.SPcheckBox6.Checked = false;
            this.SPcheckBox7.Checked = false;

        }

        private void SPCalculatebutton_Click(object sender, EventArgs e)
        {
            FracScopeModel FSM = new FracScopeModel();
            Boolean flag = true;
            //PetrelLogger.InfoBox(this.input.WellLog1.Name);

            if (this.SPtextBox1.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Clay Porosity Log (Vertical) is not specified");
                return;
            }
            if (this.SPtextBox2.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Density Porosity Log (Vertical) is not specified");
                return;
            }

            if (this.SPtextBox3.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Fracture Porosity Log (Horizontal) is not specified");
                return;
            }
            if (this.SPtextBox4.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Organic Porosity Log is not specified");
                return;
            }

            if (this.SPtextBox5.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Volume of Shale Log is not specified");
                return;
            }

            if (this.input.ReservoirTopGiven)
            {
                if (this.SPtextBox6.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Top is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirTop = FSM.PS_ConvertFromUI(Convert.ToDouble(this.SPtextBox6.Text));
                }
            }
            if (this.input.ReservoirBottomGiven)
            {
                if (this.SPtextBox7.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Bottom is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirBottom = FSM.PS_ConvertFromUI(Convert.ToDouble(this.SPtextBox7.Text));
                }
            }

            if (this.tpGPOutputtextBox.Text.Trim().Length == 0)
            {
                this.input.OutputFileName = "";
            }
            else
            {
                this.input.OutputFileName = tpGPOutputtextBox.Text;
            }

            if (flag != false)
            {
                
                Cursor.Current = Cursors.WaitCursor;

                if (!this.input.IsMultipleWelllog)
                {
                    this.input.Borehole = this.input.WellLog1.Borehole;
                    if (FSM.Calculate_SandPorosity(this.input.Borehole, this.input.WellLog1, this.input.WellLog2, this.input.WellLog3, this.input.WellLog4, this.input.WellLog5, this.input.ReservoirTop, this.input.ReservoirBottom, this.input.ReservoirTopGiven, this.input.ReservoirBottomGiven, this.input.OutputFileName))
                    {
                        //PetrelLogger.InfoBox("Vertical & Horizontal Poisson Ratio and Young Modulus Was Calculated Successfully");
                    }
                    else
                    {
                        PetrelLogger.WarnBox("Sorry, Calculation Could not be completed, Please Try again");
                    }
                }
                else
                {
                    FSM.Calculate_SandPorosity_MultipleWellLog(this.input);
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void SPtoolTipHotspot6_MouseHover(object sender, EventArgs e)
        {
            this.SPtoolTipPanel6.Visible = true;
        }

        private void SPtoolTipHotspot6_MouseLeave(object sender, EventArgs e)
        {
            this.SPtoolTipPanel6.Visible = false;
        }

        private void SPtoolTipHotspot7_MouseHover(object sender, EventArgs e)
        {
            this.SPtoolTipPanel7.Visible = true;
        }

        private void SPtoolTipHotspot7_MouseLeave(object sender, EventArgs e)
        {
            this.SPtoolTipPanel7.Visible = false;
        }

        #endregion

        #region TOP

        private void TOPdropTarget2_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));

            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv1 = dropped as WellLogVersion;
                if (this.input.Wlv1 != null)
                {
                    TOPtextBox2.Text = this.input.Wlv1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog1 = dropped as WellLog;

                if (this.input.WellLog1 != null)
                {
                    TOPtextBox2.Text = this.input.WellLog1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }


        //Delete it. User must have to give this
        private void TOP_SDNS_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }
        //Delete it. User must have to give this
        private void TOP_EDNS_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void TOP_AMD_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (TOP_AMD_checkBox.Checked)
            {
                TOPtextBox5.Clear();
                TOPtextBox5.Enabled = false;

                this.input.AssumedMatrixDensity = (float)2710.0;  //Unit Kg/m^3
            }
            else
            {
                TOPtextBox5.Enabled = true;
            }
        }

        private void TOP_DOB_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (TOP_DOB_checkBox.Checked)
            {
                TOPtextBox7.Clear();
                TOPtextBox7.Enabled = false;

                this.input.AssumedMatrixDensity = (float)1050.0;  //Unit Kg/m^3
            }
            else
            {
                TOPtextBox7.Enabled = true;
            }
        }

        private void TOP_RTop_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (TOP_RTop_checkBox.Checked)
            {
                TOPtextBox8.Clear();
                TOPtextBox8.Enabled = false;
                this.input.ReservoirTopGiven = false;
            }
            else
            {
                TOPtextBox8.Enabled = true;
                this.input.ReservoirTopGiven = true;
            }
        }

        private void TOP_RBottom_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (TOP_RBottom_checkBox.Checked)
            {
                TOPtextBox9.Clear();
                TOPtextBox9.Enabled = false;
                this.input.ReservoirBottomGiven = false;
            }
            else
            {
                TOPtextBox9.Enabled = true;
                this.input.ReservoirBottomGiven = true;
            }
        }

        private void TOP_Cancelbutton_Click(object sender, EventArgs e)
        {
            this.TOPtextBox2.Clear();
            this.TOPtextBox3.Clear();
            this.TOPtextBox4.Clear();
            this.TOPtextBox5.Clear();
            this.TOPtextBox6.Clear();
            this.TOPtextBox7.Clear();
            this.TOPtextBox8.Clear();
            this.TOPtextBox9.Clear();

            this.TOP_AMD_checkBox.Checked = false;
            this.TOP_DOB_checkBox.Checked = false;
            this.TOP_RTop_checkBox.Checked = false;
            this.TOP_RBottom_checkBox.Checked = false;
        }

        private void TOPCalculatebutton_Click(object sender, EventArgs e)
        {
            FracScopeModel FSM = new FracScopeModel();
            Boolean flag = true;

            if (this.TOPtextBox2.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Density Log is not specified");
                return;
            }

            if (this.TOPtextBox3.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Start Depth of non Kerogen Shale is not specified");
                return;
            }
            else
            {
                this.input.StartDepthOfNonkerogenShale = FSM.PS_ConvertFromUI(Convert.ToDouble(TOPtextBox3.Text));
            }

            if (this.TOPtextBox4.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("End Depth of non Kerogen Shale is not specified");
                return;
            }
            else
            {
                this.input.EndDepthOfNonKerogenShale = FSM.PS_ConvertFromUI(Convert.ToDouble(TOPtextBox4.Text));
            }

            if (!this.TOP_AMD_checkBox.Checked)
            {
                if (this.TOPtextBox5.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Assumed Matrix Density is not specified");
                    return;
                }
                else
                {
                    this.input.AssumedMatrixDensity = (float)Convert.ToDouble(this.TOPtextBox5.Text);
                }
            }

            if (this.TOPtextBox6.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Assumed Kerogen Density is not specified");
                return;
            }
            else
            {
                this.input.AssumedKerogenDensity = (float)Convert.ToDouble(this.TOPtextBox6.Text);
            }

            if (!this.TOP_DOB_checkBox.Checked)
            {
                if (this.TOPtextBox7.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Density of Brine is not specified");
                    return;
                }
                else
                {
                    this.input.DensityOfBrine = (float)Convert.ToDouble(this.TOPtextBox7.Text);
                }

            }
            
            if (this.input.ReservoirTopGiven)
            {
                if (this.TOPtextBox8.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Top is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirTop = FSM.PS_ConvertFromUI(Convert.ToDouble(TOPtextBox8.Text));
                }
            }
            if (this.input.ReservoirBottomGiven)
            {
                if (this.TOPtextBox9.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Bottom is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirBottom = FSM.PS_ConvertFromUI(Convert.ToDouble(TOPtextBox9.Text));
                }
            }

            if (this.tpGPOutputtextBox.Text.Trim().Length == 0)
            {
                this.input.OutputFileName = "";
            }
            else
            {
                this.input.OutputFileName = tpGPOutputtextBox.Text;
            }

            if (flag != false)
            {
                
                Cursor.Current = Cursors.WaitCursor;
                if (!this.input.IsMultipleWelllog)
                {
                    this.input.Borehole = this.input.WellLog1.Borehole;
                    if (FSM.Calculate_TotalOrganicCarbon(this.input.Borehole, this.input.WellLog1, this.input.ReservoirTop, this.input.ReservoirBottom, this.input.ReservoirTopGiven, this.input.ReservoirBottomGiven, this.input.StartDepthOfNonkerogenShale, this.input.EndDepthOfNonKerogenShale, this.input.AssumedMatrixDensity, this.input.AssumedKerogenDensity, this.input.DensityOfBrine, this.input.OutputFileName))
                    {
                        PetrelLogger.InfoBox("Total Organic Carbon Was Calculated Successfully");
                    }
                    else
                    {
                        PetrelLogger.WarnBox("Sorry, Calculation Could not be completed, Please Try again");
                    }
                }
                else
                {
                    FSM.Calculate_TotalOrganicCarbon_MultipleWellLogs(this.input);
                }
                Cursor.Current = Cursors.WaitCursor;
            }


        }

        private void TOPtoolTipHotspot1_MouseHover(object sender, EventArgs e)
        {
            this.TOPtoolTipPanel1.Visible = true;
        }

        private void TOPtoolTipHotspot1_MouseLeave(object sender, EventArgs e)
        {
            this.TOPtoolTipPanel1.Visible = false;
        }

        private void TOPtoolTipHotspot2_MouseHover(object sender, EventArgs e)
        {
            this.TOPtoolTipPanel2.Visible = true;
        }

        private void TOPtoolTipHotspot2_MouseLeave(object sender, EventArgs e)
        {
            this.TOPtoolTipPanel2.Visible = false;
        }

        private void TOPtoolTipHotspot3_MouseHover(object sender, EventArgs e)
        {
            this.TOPtoolTipPanel3.Visible = true;
        }

        private void TOPtoolTipHotspot3_MouseLeave(object sender, EventArgs e)
        {
            this.TOPtoolTipPanel3.Visible = false;
        }

        private void TOPtoolTipHotspot4_MouseHover(object sender, EventArgs e)
        {
            this.TOPtoolTipPanel4.Visible = true;
        }

        private void TOPtoolTipHotspot4_MouseLeave(object sender, EventArgs e)
        {
            this.TOPtoolTipPanel4.Visible = false;
        }

        private void TOPtoolTipHotspot5_MouseHover(object sender, EventArgs e)
        {
            this.TOPtoolTipPanel5.Visible = true;
        }

        private void TOPtoolTipHotspot5_MouseLeave(object sender, EventArgs e)
        {
            this.TOPtoolTipPanel5.Visible = false;
        }

        private void TOPtoolTipHotspot6_MouseHover(object sender, EventArgs e)
        {
            this.TOPtoolTipPanel6.Visible = true;
        }

        private void TOPtoolTipHotspot6_MouseLeave(object sender, EventArgs e)
        {
            this.TOPtoolTipPanel6.Visible = false;
        }

        private void TOPtoolTipHotspot7_MouseHover(object sender, EventArgs e)
        {
            this.TOPtoolTipPanel7.Visible = true;
        }

        private void TOPtoolTipHotspot7_MouseLeave(object sender, EventArgs e)
        {
            this.TOPtoolTipPanel7.Visible = false;
        }


        #endregion

        #region TOC2



        private void TOC2dropTarget1_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));

            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv1 = dropped as WellLogVersion;
                if (this.input.Wlv1 != null)
                {
                    TOC2textBox1.Text = this.input.Wlv1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog1 = dropped as WellLog;
                if (this.input.WellLog1 != null)
                {
                    TOC2textBox1.Text = this.input.WellLog1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void TOC2checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (TOC2checkBox3.Checked)
            {
                TOC2textBox3.Clear();
                TOC2textBox3.Enabled = false;
                this.input.ReservoirTopGiven = false;
            }
            else
            {
                TOC2textBox3.Enabled = true;
                this.input.ReservoirTopGiven = true;
            }
        }

        private void TOC2checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (TOC2checkBox4.Checked)
            {
                TOC2textBox4.Clear();
                TOC2textBox4.Enabled = false;
                this.input.ReservoirBottomGiven = false;
            }
            else
            {
                TOC2textBox4.Enabled = true;
                this.input.ReservoirBottomGiven = true;
            }
        }

        private void TOC2Cancelbutton_Click(object sender, EventArgs e)
        {
            this.TOC2textBox1.Clear();
            this.TOC2textBox2.Clear();
            this.TOC2textBox3.Clear();
            this.TOC2textBox4.Clear();

            this.TOC2checkBox3.Checked = false;
            this.TOC2checkBox4.Checked = false;
        }

        private void TOC2Calculatebutton_Click(object sender, EventArgs e)
        {
            FracScopeModel FSM = new FracScopeModel();
            Boolean flag = true;

            if (this.TOC2textBox1.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Density Log is not specified");
                return;
            }

            if (this.TOC2textBox2.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Grain Density is not specified");
                return;
            }
            else
            {
                this.input.GrainDensity = (float)(Convert.ToDouble(TOC2textBox2.Text));
            }
            if (this.input.ReservoirTopGiven)
            {
                if (this.TOC2textBox3.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Top is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirTop = FSM.PS_ConvertFromUI(Convert.ToDouble(TOC2textBox3.Text));
                }
            }
            if (this.input.ReservoirBottomGiven)
            {
                if (this.TOC2textBox4.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Bottom is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirBottom = FSM.PS_ConvertFromUI(Convert.ToDouble(TOC2textBox4.Text));
                }
            }

            if (this.tpGPOutputtextBox.Text.Trim().Length == 0)
            {
                this.input.OutputFileName = "";
            }
            else
            {
                this.input.OutputFileName = tpGPOutputtextBox.Text;
            }

            if (flag != false)
            {
                
                Cursor.Current = Cursors.WaitCursor;
                if (!this.input.IsMultipleWelllog)
                {
                    this.input.Borehole = this.input.WellLog1.Borehole;
                    if (FSM.Calculate_TotalOrganicCarbon_2(this.input.Borehole, this.input.WellLog1, this.input.ReservoirTop, this.input.ReservoirBottom, this.input.ReservoirTopGiven, this.input.ReservoirBottomGiven, this.input.GrainDensity, this.input.OutputFileName))
                    {
                        //PetrelLogger.InfoBox("Total Organic Carbon Was Calculated Successfully");
                    }
                    else
                    {
                        PetrelLogger.WarnBox("Sorry, Calculation Could not be completed, Please Try again");
                    }
                }
                else
                {
                    FSM.Calculate_TotalOrganicCarbon_2_MultipleWellLogs(this.input);
                }
                Cursor.Current = Cursors.WaitCursor;
            }

        }

        private void TOC2toolTipHotspot1_MouseHover(object sender, EventArgs e)
        {
            this.TOC2toolTipPanel1.Visible = true;
        }

        private void TOC2toolTipHotspot1_MouseLeave(object sender, EventArgs e)
        {
            this.TOC2toolTipPanel1.Visible = false;
        }

        private void TOC2toolTipHotspot2_MouseHover(object sender, EventArgs e)
        {
            this.TOC2toolTipPanel2.Visible = true;
        }

        private void TOC2toolTipHotspot2_MouseLeave(object sender, EventArgs e)
        {
            this.TOC2toolTipPanel2.Visible = false;
        }


        #endregion

        #region VSH
        private void VSHCalculate_Click(object sender, EventArgs e)
        {
            FracScopeModel FSM = new FracScopeModel();
            Boolean flag = true;
           
            if (this.VSHtextBox2.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Density Porosity Log is not specified");
                return;
            }
            if (this.VSHtextBox3.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Neutron Log is not specified");
                return;
            }

            
            if (this.VSHtextBox4.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Pure Shale Depth Point is not specified");
                return;
            }
            else 
            {
                this.input.UserDepth = FSM.PS_ConvertFromUI(Convert.ToDouble(VSHtextBox4.Text));
            }

            if (this.input.ReservoirTopGiven)
            {
                if (this.VSHtextBox5.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Top is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirTop = FSM.PS_ConvertFromUI(Convert.ToDouble(VSHtextBox5.Text));
                }
            }
            if (this.input.ReservoirBottomGiven)
            {
                if (this.VSHtextBox6.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Bottom is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirBottom = FSM.PS_ConvertFromUI(Convert.ToDouble(VSHtextBox6.Text));
                }
            }

            if (this.tpGPOutputtextBox.Text.Trim().Length == 0)
            {
                this.input.OutputFileName = "";
            }
            else
            {
                this.input.OutputFileName = tpGPOutputtextBox.Text;
            }

            if (flag != false)
            {
                
                Cursor.Current = Cursors.WaitCursor;
                if (!this.input.IsMultipleWelllog)
                {
                    this.input.Borehole = this.input.WellLog1.Borehole;
                    if (FSM.Calculate_VolumeOfShale(this.input.Borehole, this.input.WellLog2, this.input.WellLog1, this.input.ReservoirTop, this.input.ReservoirBottom, this.input.ReservoirTopGiven, this.input.ReservoirBottomGiven, this.input.UserDepth, this.input.OutputFileName))
                    {
                        //PetrelLogger.InfoBox(" Volume Of Shale Calculated Successfully");
                    }
                    else
                    {
                        PetrelLogger.WarnBox("Sorry, Calculation Could not be completed, Please Try again");
                    }
                }
                else 
                {
                    FSM.Calculate_VolumeOfShale_MultipleWellLogs(this.input);
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void VSHdropTarget2_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv1 = dropped as WellLogVersion;
                if (this.input.Wlv1 != null)
                {
                    VSHtextBox2.Text = this.input.Wlv1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog1 = dropped as WellLog;
                if (this.input.WellLog1 != null)
                {
                    VSHtextBox2.Text = this.input.WellLog1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }

        }

        private void VSHdropTarget3_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv2 = dropped as WellLogVersion;
                if (this.input.Wlv2 != null)
                {
                    VSHtextBox3.Text = this.input.Wlv2.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog2 = dropped as WellLog;
                if (this.input.WellLog2 != null)
                {
                    VSHtextBox3.Text = this.input.WellLog2.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }


        private void VSHcheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (VSHcheckBox1.Checked)
            {
                VSHtextBox5.Clear();
                VSHtextBox5.Enabled = false;
                this.input.ReservoirTopGiven = false;
            }
            else
            {
                VSHtextBox5.Enabled = true;
                this.input.ReservoirTopGiven = true;
            }
        }

        private void VSHcheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (VSHcheckBox2.Checked)
            {
                VSHtextBox6.Clear();
                VSHtextBox6.Enabled = false;
                this.input.ReservoirBottomGiven = false;
            }
            else
            {
                VSHtextBox6.Enabled = true;
                this.input.ReservoirBottomGiven = true;
            }

        }

        private void VSHCancelbutton2_Click(object sender, EventArgs e)
        {
            this.VSHtextBox2.Clear();
            this.VSHtextBox3.Clear();
            this.VSHtextBox4.Clear();
            this.VSHtextBox5.Clear();
            this.VSHtextBox6.Clear();
            this.VSHcheckBox1.Checked = false;
            this.VSHcheckBox2.Checked = false;

        }

        private void VShtoolTipHotspot1_MouseHover(object sender, EventArgs e)
        {
            this.VShtoolTipPanel1.Visible = true;
        }

        private void VShtoolTipHotspot1_MouseLeave(object sender, EventArgs e)
        {
            this.VShtoolTipPanel1.Visible = false;
        }

        private void VShtoolTipHotspot2_MouseHover(object sender, EventArgs e)
        {
            this.VShtoolTipPanel2.Visible = true;
        }

        private void VShtoolTipHotspot2_MouseLeave(object sender, EventArgs e)
        {
            this.VShtoolTipPanel2.Visible = false;
        }

        private void VShtoolTipHotspot3_MouseHover(object sender, EventArgs e)
        {
            this.VShtoolTipPanel3.Visible = true;
        }

        private void VShtoolTipHotspot3_MouseLeave(object sender, EventArgs e)
        {
            this.VShtoolTipPanel3.Visible = false;
        }
        #endregion




        #region AA

        private void AAdropTarget2_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv1 = dropped as WellLogVersion;
                if (this.input.Wlv1 != null)
                {
                    AAtextBox2.Text = this.input.Wlv1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog1 = dropped as WellLog;
                if (this.input.WellLog1 != null)
                {
                    AAtextBox2.Text = this.input.WellLog1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void AAdropTarget3_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv2 = dropped as WellLogVersion;
                if (this.input.Wlv2 != null)
                {
                    AAtextBox3.Text = this.input.Wlv2.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog2 = dropped as WellLog;
                if (this.input.WellLog2 != null)
                {
                    AAtextBox3.Text = this.input.WellLog2.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void AAcheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (AAcheckBox1.Checked)
            {
                AAtextBox4.Clear();
                AAtextBox4.Enabled = false;
                this.input.ReservoirTopGiven = false;
            }
            else
            {
                AAtextBox4.Enabled = true;
                this.input.ReservoirTopGiven = true;
            }
        }

        private void AAcheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (AAcheckBox2.Checked)
            {
                AAtextBox5.Clear();
                AAtextBox5.Enabled = false;
                this.input.ReservoirBottomGiven = false;
            }
            else
            {
                AAtextBox5.Enabled = true;
                this.input.ReservoirBottomGiven = true;
            }
        }

        private void AACancelbutton_Click(object sender, EventArgs e)
        {
            AAtextBox2.Clear();
            AAtextBox3.Clear();
            AAtextBox4.Clear();
            AAtextBox5.Clear();

            AAcheckBox1.Checked = false;
            AAcheckBox2.Checked = false;
        }

        private void AACalculatebutton_Click(object sender, EventArgs e)
        {
            FracScopeModel FSM = new FracScopeModel();
            Boolean flag = true;

            if (this.AAtextBox2.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Di-Pole Sonic Log (Fast) is not specified");
                return;
            }
            if (this.AAtextBox3.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Di-Pole Sonic Log (Slow) is not specified");
                return;
            }

            if (this.input.ReservoirTopGiven)
            {
                if (this.AAtextBox4.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Top is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirTop = FSM.PS_ConvertFromUI(Convert.ToDouble(this.AAtextBox4.Text));
                }
            }
            if (this.input.ReservoirBottomGiven)
            {
                if (this.AAtextBox5.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Bottom is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirBottom = FSM.PS_ConvertFromUI(Convert.ToDouble(this.AAtextBox5.Text));
                }
            }

            if (this.tpGEOutputtextBox.Text.Trim().Length == 0)
            {
                this.input.OutputFileName = "";
            }
            else
            {
                this.input.OutputFileName = tpGEOutputtextBox.Text;
            }

            if (flag != false)
            {
                
                Cursor.Current = Cursors.WaitCursor;
                if (!this.input.IsMultipleWelllog)
                {
                    this.input.Borehole = this.input.WellLog1.Borehole;
                    if (FSM.Calculate_AzimuthalAnisotropy(this.input.Borehole, this.input.WellLog1, this.input.WellLog2, this.input.ReservoirTop, this.input.ReservoirBottom, this.input.ReservoirTopGiven, this.input.ReservoirBottomGiven, this.input.OutputFileName))
                    {
                        //PetrelLogger.InfoBox("Azimuth Anistropy Was Walculated Successfully");
                    }
                    else
                    {
                        PetrelLogger.WarnBox("Sorry, Calculation Could not be completed, Please Try again");
                    }
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void AAtoolTipHotspot1_MouseHover(object sender, EventArgs e)
        {
            this.AAtoolTipPanel1.Visible = true;
        }

        private void AAtoolTipHotspot1_MouseLeave(object sender, EventArgs e)
        {
            this.AAtoolTipPanel1.Visible = false;
        }

        private void AAtoolTipHotspot2_MouseHover(object sender, EventArgs e)
        {
            this.AAtoolTipPanel2.Visible = true;
        }

        private void AAtoolTipHotspot2_MouseLeave(object sender, EventArgs e)
        {
            this.AAtoolTipPanel2.Visible = false;
        }

        #endregion

        #region BI

        private void BIdropTarget2_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv1 = dropped as WellLogVersion;
                if (this.input.Wlv1 != null)
                {
                    BItextBox2.Text = this.input.Wlv1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog1 = dropped as WellLog;
                if (this.input.WellLog1 != null)
                {
                    BItextBox2.Text = this.input.WellLog1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void BIdropTarget3_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv2 = dropped as WellLogVersion;
                if (this.input.Wlv2 != null)
                {
                    BItextBox3.Text = this.input.Wlv2.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog2 = dropped as WellLog;
                if (this.input.WellLog2 != null)
                {
                    BItextBox3.Text = this.input.WellLog2.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void BIcheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (BIcheckBox1.Checked)
            {
                BItextBox4.Clear();
                BItextBox4.Enabled = false;
                this.input.ReservoirTopGiven = false;
            }
            else
            {
                BItextBox4.Enabled = true;
                this.input.ReservoirTopGiven = true;
            }
        }

        private void BIcheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (BIcheckBox2.Checked)
            {
                BItextBox5.Clear();
                BItextBox5.Enabled = false;
                this.input.ReservoirBottomGiven = false;
            }
            else
            {
                BItextBox5.Enabled = true;
                this.input.ReservoirBottomGiven = true;
            }
        }

        private void BICancelbutton_Click(object sender, EventArgs e)
        {
            BItextBox2.Clear();
            BItextBox3.Clear();
            BItextBox4.Clear();
            BItextBox5.Clear();

            BIcheckBox1.Checked = false;
            BIcheckBox2.Checked = false;
        }

        private void BICalculatebutton_Click(object sender, EventArgs e)
        {
            FracScopeModel FSM = new FracScopeModel();
            Boolean flag = true;

            if (this.BItextBox2.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Poisson Ratio Log is not specified");
                return;
            }
            if (this.BItextBox3.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Young Modulas Log is not specified");
                return;
            }


            if (this.input.ReservoirTopGiven)
            {
                if (this.BItextBox4.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Top is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirTop = FSM.PS_ConvertFromUI(Convert.ToDouble(this.BItextBox4.Text));
                }
            }
            if (this.input.ReservoirBottomGiven)
            {
                if (this.BItextBox5.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Bottom is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirBottom = FSM.PS_ConvertFromUI(Convert.ToDouble(this.BItextBox5.Text));
                }
            }

            if (this.tpGEOutputtextBox.Text.Trim().Length == 0)
            {
                this.input.OutputFileName = "";
            }
            else
            {
                this.input.OutputFileName = tpGEOutputtextBox.Text;
            }

            if (flag != false)
            {
                
                Cursor.Current = Cursors.WaitCursor;

                if (!this.input.IsMultipleWelllog)
                {
                    this.input.Borehole = this.input.WellLog1.Borehole;
                    if (FSM.Calculate_BrittlenessIndex(this.input.Borehole, this.input.WellLog1, this.input.WellLog2, this.input.ReservoirTop, this.input.ReservoirBottom, this.input.ReservoirTopGiven, this.input.ReservoirBottomGiven, this.input.OutputFileName))
                    {
                        //PetrelLogger.InfoBox("Brittleness index Was Calculated Successfully");
                    }
                    else
                    {
                        PetrelLogger.WarnBox("Sorry, Calculation Could not be completed, Please Try again");
                    }
                }
                else
                {
                    FSM.Calculate_BrittlenessIndex_MultipleWellLog(this.input);
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void BItoolTipHotspot1_MouseHover(object sender, EventArgs e)
        {
            this.BItoolTipPanel1.Visible = true;
        }

        private void BItoolTipHotspot1_MouseLeave(object sender, EventArgs e)
        {
            this.BItoolTipPanel1.Visible = false;
        }

        private void BItoolTipHotspot2_MouseHover(object sender, EventArgs e)
        {
            this.BItoolTipPanel2.Visible = true;
        }

        private void BItoolTipHotspot2_MouseLeave(object sender, EventArgs e)
        {
            this.BItoolTipPanel2.Visible = false;
        }

        #endregion

        #region Epsilon

        private void EdropTarget2_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv1 = dropped as WellLogVersion;
                if (this.input.Wlv1 != null)
                {
                    EtextBox2.Text = this.input.Wlv1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog1 = dropped as WellLog;
                if (this.input.WellLog1 != null)
                {
                    EtextBox2.Text = this.input.WellLog1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void EdropTarget3_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv2 = dropped as WellLogVersion;
                if (this.input.Wlv2 != null)
                {
                    EtextBox3.Text = this.input.Wlv2.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog2 = dropped as WellLog;
                if (this.input.WellLog2 != null)
                {
                    EtextBox3.Text = this.input.WellLog2.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void EcheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (EcheckBox1.Checked)
            {
                EtextBox4.Clear();
                EtextBox4.Enabled = false;
                this.input.ReservoirTopGiven = false;
            }
            else
            {
                EtextBox4.Enabled = true;
                this.input.ReservoirTopGiven = true;
            }
        }

        private void EcheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (EcheckBox2.Checked)
            {
                EtextBox5.Clear();
                EtextBox5.Enabled = false;
                this.input.ReservoirBottomGiven = false;
            }
            else
            {
                EtextBox5.Enabled = true;
                this.input.ReservoirBottomGiven = true;
            }
        }

        private void ECancelbutton_Click(object sender, EventArgs e)
        {
            
            EtextBox2.Clear();
            EtextBox3.Clear();
            EtextBox4.Clear();
            EtextBox5.Clear();

            EcheckBox1.Checked = false;
            EcheckBox2.Checked = false;
        }

        private void ECalculatebutton_Click(object sender, EventArgs e)
        {
            FracScopeModel FSM = new FracScopeModel();
            Boolean flag = true;

            if (this.EtextBox2.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("C11 Log is not specified");
                return;
            }
            if (this.EtextBox3.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("C33 Log is not specified");
                return;
            }

            if (this.input.ReservoirTopGiven)
            {
                if (this.EtextBox4.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Top is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirTop = FSM.PS_ConvertFromUI(Convert.ToDouble(this.EtextBox4.Text));
                }
            }
            if (this.input.ReservoirBottomGiven)
            {
                if (this.EtextBox5.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Bottom is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirBottom = FSM.PS_ConvertFromUI(Convert.ToDouble(this.EtextBox5.Text));
                }
            }

            if (this.tpGEOutputtextBox.Text.Trim().Length == 0)
            {
                this.input.OutputFileName = "";
            }
            else
            {
                this.input.OutputFileName = tpGEOutputtextBox.Text;
            }

            if (flag != false)
            {
                
                Cursor.Current = Cursors.WaitCursor;

                if (!this.input.IsMultipleWelllog)
                {
                    this.input.Borehole = this.input.WellLog1.Borehole;
                    if (FSM.Calculate_Epsilon(this.input.Borehole, this.input.WellLog1, this.input.WellLog2, this.input.ReservoirTop, this.input.ReservoirBottom, this.input.ReservoirTopGiven, this.input.ReservoirBottomGiven, this.input.OutputFileName))
                    {
                        //PetrelLogger.InfoBox("Epsilon Was Calculated Successfully");
                    }
                    else
                    {
                        PetrelLogger.WarnBox("Sorry, Calculation Could not be completed, Please Try again");
                    }
                }
                else
                {
                    FSM.Calculate_Epsilon_MultipleWellLog(this.input);
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void EtoolTipHotspot1_MouseHover(object sender, EventArgs e)
        {
            this.EtoolTipPanel1.Visible = true;
        }

        private void EtoolTipHotspot1_MouseLeave(object sender, EventArgs e)
        {
            this.EtoolTipPanel1.Visible = false;
        }

        private void EtoolTipHotspot2_MouseHover(object sender, EventArgs e)
        {
            this.EtoolTipPanel2.Visible = true;
        }

        private void EtoolTipHotspot2_MouseLeave(object sender, EventArgs e)
        {
            this.EtoolTipPanel2.Visible = false;
        }


        #endregion

        #region Gamma

        private void GdropTarget2_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv1 = dropped as WellLogVersion;
                if (this.input.Wlv1 != null)
                {
                    GtextBox2.Text = this.input.Wlv1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog1 = dropped as WellLog;
                if (this.input.WellLog1 != null)
                {
                    GtextBox2.Text = this.input.WellLog1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void GdropTarget3_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv2 = dropped as WellLogVersion;
                if (this.input.Wlv2 != null)
                {
                    GtextBox3.Text = this.input.Wlv2.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog2 = dropped as WellLog;
                if (this.input.WellLog2 != null)
                {
                    GtextBox3.Text = this.input.WellLog2.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void GcheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (GcheckBox1.Checked)
            {
                GtextBox4.Clear();
                GtextBox4.Enabled = false;
                this.input.ReservoirTopGiven = false;
            }
            else
            {
                GtextBox4.Enabled = true;
                this.input.ReservoirTopGiven = true;
            }
        }

        private void GcheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (GcheckBox2.Checked)
            {
                GtextBox5.Clear();
                GtextBox5.Enabled = false;
                this.input.ReservoirBottomGiven = false;
            }
            else
            {
                GtextBox5.Enabled = true;
                this.input.ReservoirBottomGiven = true;
            }
        }

        private void GCancelbutton_Click(object sender, EventArgs e)
        {
            this.GtextBox2.Clear();
            this.GtextBox3.Clear();
            this.GtextBox4.Clear();
            this.GtextBox5.Clear();
            this.GcheckBox1.Checked = false;
            this.GcheckBox2.Checked = false;
        }

        private void GCalculatebutton_Click(object sender, EventArgs e)
        {
            FracScopeModel FSM = new FracScopeModel();
            Boolean flag = true;
            
            if (this.GtextBox2.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("C66 Log is not specified");
                return;
            }
            if (this.GtextBox3.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("C44 Log is not specified");
                return;
            }
            if (this.input.ReservoirTopGiven)
            {
                if (this.GtextBox4.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Top is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirTop = FSM.PS_ConvertFromUI(Convert.ToDouble(GtextBox4.Text));
                }
            }
            if (this.input.ReservoirBottomGiven)
            {
                if (this.GtextBox5.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Bottom is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirBottom = FSM.PS_ConvertFromUI(Convert.ToDouble(GtextBox5.Text));
                }
            }

            if (this.tpGEOutputtextBox.Text.Trim().Length == 0)
            {
                this.input.OutputFileName = "";
            }
            else
            {
                this.input.OutputFileName = tpGEOutputtextBox.Text;
            }

            if (flag != false)
            {
                
                Cursor.Current = Cursors.WaitCursor;

                if (!this.input.IsMultipleWelllog)
                {
                    this.input.Borehole = this.input.WellLog1.Borehole;
                    if (FSM.Calculate_Gamma(this.input.Borehole, this.input.WellLog1, this.input.WellLog2, this.input.ReservoirTop, this.input.ReservoirBottom, this.input.ReservoirTopGiven, this.input.ReservoirBottomGiven, this.input.OutputFileName))
                    {
                        //PetrelLogger.InfoBox("Gamma Was Calculated Successfully");
                    }
                    else
                    {
                        PetrelLogger.WarnBox("Sorry, Calculation Could not be completed, Please Try again");
                    }
                }
                else
                {
                    FSM.Calculate_Gamma_MultipleWellLog(this.input);
                }
                Cursor.Current = Cursors.Default;
            }

        }

        private void GtoolTipHotspot1_MouseHover(object sender, EventArgs e)
        {
            this.GtoolTipPanel1.Visible = true;
        }

        private void GtoolTipHotspot1_MouseLeave(object sender, EventArgs e)
        {
            this.GtoolTipPanel1.Visible = false;
        }

        private void GtoolTipHotspot2_MouseHover(object sender, EventArgs e)
        {
            this.GtoolTipPanel2.Visible = true;
        }

        private void GtoolTipHotspot2_MouseLeave(object sender, EventArgs e)
        {
            this.GtoolTipPanel2.Visible = false;
        }


        #endregion

        #region MHS



        private void MHSdropTarget1_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv1 = dropped as WellLogVersion;
                if (this.input.Wlv1 != null)
                {
                    MHStextBox1.Text = this.input.Wlv1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog1 = dropped as WellLog;
                if (this.input.WellLog1 != null)
                {
                    MHStextBox1.Text = this.input.WellLog1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void MHSdropTarget2_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv2 = dropped as WellLogVersion;
                if (this.input.Wlv2 != null)
                {
                    MHStextBox2.Text = this.input.Wlv2.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog2 = dropped as WellLog;
                if (this.input.WellLog2 != null)
                {
                    MHStextBox2.Text = this.input.WellLog2.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void MHSdropTarget3_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv3 = dropped as WellLogVersion;
                if (this.input.Wlv3 != null)
                {
                    MHStextBox3.Text = this.input.Wlv3.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog3 = dropped as WellLog;
                if (this.input.WellLog3 != null)
                {
                    MHStextBox3.Text = this.input.WellLog3.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void MHSdropTarget4_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv4 = dropped as WellLogVersion;
                if (this.input.Wlv4 != null)
                {
                    MHStextBox4.Text = this.input.Wlv4.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog4 = dropped as WellLog;
                if (this.input.WellLog4 != null)
                {
                    MHStextBox4.Text = this.input.WellLog4.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void MHSCancelbutton_Click(object sender, EventArgs e)
        {
            this.MHStextBox1.Clear();
            this.MHStextBox2.Clear();
            this.MHStextBox3.Clear();
            this.MHStextBox4.Clear();
            this.MHStextBox5.Clear();
            this.MHStextBox6.Clear();
            this.MHStextBox7.Clear();
            this.MHStextBox8.Clear();
            this.MHStextBox9.Clear();

            this.MHScheckBox5.Checked = false;
            this.MHScheckBox6.Checked = false;
            this.MHScheckBox7.Checked = false;
            this.MHScheckBox8.Checked = false;
            this.MHScheckBox9.Checked = false;
        }

        private void MHSCalculatebutton_Click(object sender, EventArgs e)
        {
            FracScopeModel FSM = new FracScopeModel();
            Boolean flag = true;
            

            if (this.MHStextBox1.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Poisson Ratio Log (Vertical) is not specified");
                return;
            }
            if (this.MHStextBox2.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Vertical Stress Log (Vertical) is not specified");
                return;
            }

            if (this.MHStextBox3.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Pore Pressure Log (Horizontal) is not specified");
                return;
            }
            if (this.MHStextBox4.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Young's Modulus Log is not specified");
                return;
            }

            if (!this.MHScheckBox5.Checked)
            {
                if (this.MHStextBox5.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Biot's Constant is not specified");
                    return;
                }
                else
                {
                    this.input.BiotConstant = (float)Convert.ToDouble(this.MHStextBox5.Text);
                }
            }

            if (!this.MHScheckBox6.Checked)
            {
                if (this.MHStextBox6.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Min Horizontal Strain is not specified");
                    return;
                }
                else
                {
                    this.input.MinHorStrain = (float)Convert.ToDouble(this.MHStextBox6.Text);
                }
            }

            if (!this.MHScheckBox7.Checked)
            {
                if (this.MHStextBox7.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("BMax Horizontal Strain is not specified");
                    return;
                }
                else
                {
                    this.input.MaxHorStrain = (float)Convert.ToDouble(this.MHStextBox7.Text);
                }
            }
            if (this.input.ReservoirTopGiven)
            {
                if (this.MHStextBox8.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Top is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirTop = FSM.PS_ConvertFromUI(Convert.ToDouble(this.MHStextBox8.Text));
                }
            }
            if (this.input.ReservoirBottomGiven)
            {
                if (this.MHStextBox9.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Bottom is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirBottom = FSM.PS_ConvertFromUI(Convert.ToDouble(this.MHStextBox9.Text));
                }
            }

            if (this.tpGPOutputtextBox.Text.Trim().Length == 0)
            {
                this.input.OutputFileName = "";
            }
            else
            {
                this.input.OutputFileName = tpGPOutputtextBox.Text;
            }

            if (flag != false)
            {
                
                Cursor.Current = Cursors.WaitCursor;

                if (!this.input.IsMultipleWelllog)
                {
                    this.input.Borehole = this.input.WellLog1.Borehole;
                    if (FSM.Calculate_MinHorStress_Isotropic(this.input.Borehole, this.input.WellLog1, this.input.WellLog2, this.input.WellLog3, this.input.WellLog4, this.input.ReservoirTop, this.input.ReservoirBottom, this.input.ReservoirTopGiven, this.input.ReservoirBottomGiven, this.input.BiotConstant, this.input.MinHorStrain, this.input.MaxHorStrain, this.input.OutputFileName))
                    {
                        //PetrelLogger.InfoBox("Vertical & Horizontal Poisson Ratio and Young Modulus Was Calculated Successfully");
                    }
                    else
                    {
                        PetrelLogger.WarnBox("Sorry, Calculation Could not be completed, Please Try again");
                    }
                }
                else
                {
                    FSM.Calculate_MinHorStress_Isotropic_MultipleWellLog(this.input);
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void MHScheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (MHScheckBox5.Checked)
            {
                MHStextBox5.Clear();
                MHStextBox5.Enabled = false;
                this.input.BiotConstantGiven = false;
                this.input.BiotConstant = 1;
            }
            else
            {
                MHStextBox5.Enabled = true;
                this.input.BiotConstantGiven = true;
            }
        }

        private void MHScheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (MHScheckBox6.Checked)
            {
                MHStextBox6.Clear();
                MHStextBox6.Enabled = false;
                this.input.MinHorStrainGiven = false;
                this.input.MinHorStrain = 0;
            }
            else
            {
                MHStextBox6.Enabled = true;
                this.input.MinHorStrainGiven = true;
            }
        }

        private void MHScheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (MHScheckBox7.Checked)
            {
                MHStextBox7.Clear();
                MHStextBox7.Enabled = false;
                this.input.MaxHorStrainGiven = false;
                this.input.MaxHorStrain = 0;
            }
            else
            {
                MHStextBox7.Enabled = true;
                this.input.MaxHorStrainGiven = true;
            }
        }

        private void MHScheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (MHScheckBox8.Checked)
            {
                MHStextBox8.Clear();
                MHStextBox8.Enabled = false;
                this.input.ReservoirTopGiven = false;
            }
            else
            {
                MHStextBox8.Enabled = true;
                this.input.ReservoirTopGiven = true;
            }
        }

        private void MHScheckBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (MHScheckBox9.Checked)
            {
                MHStextBox9.Clear();
                MHStextBox9.Enabled = false;
                this.input.ReservoirBottomGiven = false;
            }
            else
            {
                MHStextBox9.Enabled = true;
                this.input.ReservoirBottomGiven = true;
            }
        }

        private void MHStoolTipHotspot5_MouseHover(object sender, EventArgs e)
        {
            this.MHStoolTipPanel5.Visible = true;
        }

        private void MHStoolTipHotspot5_MouseLeave(object sender, EventArgs e)
        {
            this.MHStoolTipPanel5.Visible = false;
        }

        private void MHStoolTipHotspot6_MouseHover(object sender, EventArgs e)
        {
            this.MHStoolTipPanel6.Visible = true;
        }

        private void MHStoolTipHotspot6_MouseLeave(object sender, EventArgs e)
        {
            this.MHStoolTipPanel6.Visible = false;
        }

        private void MHStoolTipHotspot7_MouseHover(object sender, EventArgs e)
        {
            this.MHStoolTipPanel7.Visible = true;
        }

        private void MHStoolTipHotspot7_MouseLeave(object sender, EventArgs e)
        {
            this.MHStoolTipPanel7.Visible = false;
        }

        private void MHStoolTipHotspot8_MouseHover(object sender, EventArgs e)
        {
            this.MHStoolTipPanel8.Visible = true;
        }

        private void MHStoolTipHotspot8_MouseLeave(object sender, EventArgs e)
        {
            this.MHStoolTipPanel8.Visible = false;
        }

        private void MHStoolTipHotspot9_MouseHover(object sender, EventArgs e)
        {
            this.MHStoolTipPanel9.Visible = true;
        }

        private void MHStoolTipHotspot9_MouseLeave(object sender, EventArgs e)
        {
            this.MHStoolTipPanel9.Visible = false;
        }


        #endregion

        #region Poisson Ratio

        private void PRdropTarget2_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv1 = dropped as WellLogVersion;
                if (this.input.Wlv1 != null)
                {
                    PRtextBox2.Text = this.input.Wlv1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog1 = dropped as WellLog;
                if (this.input.WellLog1 != null)
                {
                    PRtextBox2.Text = this.input.WellLog1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void PRdropTarget3_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv2 = dropped as WellLogVersion;
                if (this.input.Wlv2 != null)
                {
                    PRtextBox3.Text = this.input.Wlv2.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog2 = dropped as WellLog;
                if (this.input.WellLog2 != null)
                {
                    PRtextBox3.Text = this.input.WellLog2.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void PRcheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (PRcheckBox1.Checked)
            {
                PRtextBox4.Clear();
                PRtextBox4.Enabled = false;
                this.input.ReservoirTopGiven = false;
            }
            else
            {
                PRtextBox4.Enabled = true;
                this.input.ReservoirTopGiven = true;
            }
        }

        private void PRcheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (PRcheckBox2.Checked)
            {
                PRtextBox5.Clear();
                PRtextBox5.Enabled = false;
                this.input.ReservoirBottomGiven = false;
            }
            else
            {
                PRtextBox5.Enabled = true;
                this.input.ReservoirBottomGiven = true;
            }
        }

        private void PRCancelbutton_Click(object sender, EventArgs e)
        {
            this.PRtextBox2.Clear();
            this.PRtextBox3.Clear();
            this.PRtextBox4.Clear();
            this.PRtextBox5.Clear();
            this.PRcheckBox1.Checked = false;
            this.PRcheckBox2.Checked = false;
        }

        private void PRCalculatebutton_Click(object sender, EventArgs e)
        {
            FracScopeModel FSM = new FracScopeModel();
            Boolean flag = true;
            //PetrelLogger.InfoBox(this.input.WellLog1.Name);

            if (this.PRtextBox2.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("P Wave Sonic Log is not specified");
                return;
            }
            if (this.PRtextBox3.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("S Wave Sonic Log is not specified");
                return;
            }
            if (this.input.ReservoirTopGiven)
            {
                if (this.PRtextBox4.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Top is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirTop = FSM.PS_ConvertFromUI(Convert.ToDouble(PRtextBox4.Text));
                }
            }
            if (this.input.ReservoirBottomGiven)
            {
                if (this.PRtextBox5.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Bottom is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirBottom = FSM.PS_ConvertFromUI(Convert.ToDouble(PRtextBox5.Text));
                }
            }

            if (this.tpGEOutputtextBox.Text.Trim().Length == 0)
            {
                this.input.OutputFileName = "";
            }
            else
            {
                this.input.OutputFileName = tpGEOutputtextBox.Text;
            }

            if (flag != false)
            {
                
                Cursor.Current = Cursors.WaitCursor;

                if (!this.input.IsMultipleWelllog)
                {
                    this.input.Borehole = this.input.WellLog1.Borehole;
                    if (FSM.Calculate_PoissonRatio(this.input.Borehole, this.input.WellLog1, this.input.WellLog2, this.input.ReservoirTop, this.input.ReservoirBottom, this.input.ReservoirTopGiven, this.input.ReservoirBottomGiven, this.input.OutputFileName))
                    {
                        //PetrelLogger.InfoBox("Poisson's Ratio Was calculated Successfully");
                    }
                    else
                    {
                        PetrelLogger.WarnBox("Sorry, Calculation Could not be completed, Please Try again");
                    }
                }
                else
                {
                    FSM.Calculate_PoissonRatio_MultipleWellLog(this.input);
                }
                Cursor.Current = Cursors.WaitCursor;
            }
        }

        private void PRtoolTipHotspot1_MouseHover(object sender, EventArgs e)
        {
            this.PRtoolTipPanel1.Visible = true;
        }

        private void PRtoolTipHotspot1_MouseLeave(object sender, EventArgs e)
        {
            this.PRtoolTipPanel1.Visible = false;
        }

        private void PRtoolTipHotspot2_MouseHover(object sender, EventArgs e)
        {
            this.PRtoolTipPanel2.Visible = true;
        }

        private void PRtoolTipHotspot2_MouseLeave(object sender, EventArgs e)
        {
            this.PRtoolTipPanel2.Visible = false;
        }


        #endregion
        
        #region PRYMAM
        
        private void PRYMAMdropTarget2_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv1 = dropped as WellLogVersion;
                if (this.input.Wlv1 != null)
                {
                    PRYMAMtextBox2.Text = this.input.Wlv1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog1 = dropped as WellLog;
                if (this.input.WellLog1 != null)
                {
                    PRYMAMtextBox2.Text = this.input.WellLog1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void PRYMAMdropTarget3_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv2 = dropped as WellLogVersion;
                if (this.input.Wlv2 != null)
                {
                    PRYMAMtextBox3.Text = this.input.Wlv2.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog2 = dropped as WellLog;
                if (this.input.WellLog2 != null)
                {
                    PRYMAMtextBox3.Text = this.input.WellLog2.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void PRYMAMdropTarget4_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv3 = dropped as WellLogVersion;
                if (this.input.Wlv3 != null)
                {
                    PRYMAMtextBox4.Text = this.input.Wlv3.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog3 = dropped as WellLog;
                if (this.input.WellLog3 != null)
                {
                    PRYMAMtextBox4.Text = this.input.WellLog3.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void PRYMAMdropTarget5_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv4 = dropped as WellLogVersion;
                if (this.input.Wlv4 != null)
                {
                    PRYMAMtextBox5.Text = this.input.Wlv4.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog4 = dropped as WellLog;
                if (this.input.WellLog4 != null)
                {
                    PRYMAMtextBox5.Text = this.input.WellLog4.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void PRYMAMcheckBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (PRYMAMcheckBox9.Checked)
            {
                PRYMAMtextBox9.Clear();
                PRYMAMtextBox9.Enabled = false;
                this.input.PoreElasticConstantGiven = false;
                this.input.PoreElasticConstant = 0;
            }
            else
            {
                PRYMAMtextBox9.Enabled = true;
                this.input.PoreElasticConstantGiven = true;
            }
        }

        private void PRYMAMcheckBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (PRYMAMcheckBox10.Checked)
            {
                PRYMAMtextBox10.Clear();
                PRYMAMtextBox10.Enabled = false;
                this.input.MinHorStrainGiven = false;
                this.input.MinHorStrain = 0;
            }
            else
            {
                PRYMAMtextBox10.Enabled = true;
                this.input.MinHorStrainGiven = true;
            }
        }

        private void PRYMAMCancelbutton_Click(object sender, EventArgs e)
        {
            this.PRYMAMtextBox2.Clear();
            this.PRYMAMtextBox3.Clear();
            this.PRYMAMtextBox4.Clear();
            this.PRYMAMtextBox5.Clear();
            this.PRYMAMtextBox6.Clear();
            this.PRYMAMtextBox7.Clear();
            this.PRYMAMtextBox8.Clear();
            this.PRYMAMtextBox9.Clear();
            this.PRYMAMtextBox10.Clear();
            this.PRYMAMtextBox11.Clear();
            this.PRYMAMtextBox12.Clear();
            this.PRYMAMtextBox13.Clear();

            this.PRYMAMcheckBox8.Checked = false;
            this.PRYMAMcheckBox9.Checked = false;
            this.PRYMAMcheckBox10.Checked = false;
            this.PRYMAMcheckBox11.Checked = false;
            this.PRYMAMcheckBox12.Checked = false;
            this.PRYMAMcheckBox13.Checked = false;
        }

        private void PRYMAMCalculatebutton_Click(object sender, EventArgs e)
        {
            FracScopeModel FSM = new FracScopeModel();
            Boolean flag = true;
            //PetrelLogger.InfoBox(this.input.WellLog1.Name);

            if (this.PRYMAMtextBox2.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("P Wave Sonic Log (Vertical) is not specified");
                return;
            }
            if (this.PRYMAMtextBox3.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("S Wave Sonic Log (Vertical) is not specified");
                return;
            }

            if (this.PRYMAMtextBox4.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("S Wave Sonic Log (Horizontal) is not specified");
                return;
            }
            if (this.PRYMAMtextBox5.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Density Log is not specified");
                return;
            }

            if (this.PRYMAMtextBox6.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Vertical Stress Log is not specified");
                return;
            }

            if (this.PRYMAMtextBox7.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Pore Pressure Log is not specified");
                return;
            }

            if (!this.PRYMAMcheckBox8.Checked)
            {
                if (this.PRYMAMtextBox8.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Biot Constant is not specified");
                    return;
                }
                else
                {
                    this.input.BiotConstant = (float)(Convert.ToDouble(this.PRYMAMtextBox8.Text));
                }
            }

            if (!this.PRYMAMcheckBox9.Checked)
            {
                if (this.PRYMAMtextBox9.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Pore Elastic Constant is not specified");
                    return;
                }
                else
                {
                    this.input.PoreElasticConstant = (float)(Convert.ToDouble(this.PRYMAMtextBox9.Text));
                }
            }

            if (!this.PRYMAMcheckBox10.Checked)
            {
                if (this.PRYMAMtextBox10.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Min Horizontal Strain is not specified");
                    return;
                }
                else
                {
                    this.input.MinHorStrain = (float)(Convert.ToDouble(this.PRYMAMtextBox10.Text));
                }
            }

            if (!this.PRYMAMcheckBox11.Checked)
            {
                if (this.PRYMAMtextBox11.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Max Horizontal Strain is not specified");
                    return;
                }
                else
                {
                    this.input.MaxHorStrain = (float)(Convert.ToDouble(this.PRYMAMtextBox11.Text));
                }
            }

            if (this.input.ReservoirTopGiven)
            {
                if (this.PRYMAMtextBox12.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Top is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirTop = FSM.PS_ConvertFromUI(Convert.ToDouble(this.PRYMAMtextBox12.Text));
                }
            }
            if (this.input.ReservoirBottomGiven)
            {
                if (this.PRYMAMtextBox13.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Bottom is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirBottom = FSM.PS_ConvertFromUI(Convert.ToDouble(this.PRYMAMtextBox12.Text));
                }
            }

            if (this.OutputPRYM2textBox1.Text.Trim().Length == 0)
            {
                this.input.OutputFileNameList.Add("");
            }
            else
            {
                this.input.OutputFileNameList.Add(OutputPRYM2textBox1.Text);
            }
            if (this.OutputPRYM2textBox2.Text.Trim().Length == 0)
            {
                this.input.OutputFileNameList.Add("");
            }
            else
            {
                this.input.OutputFileNameList.Add(OutputPRYM2textBox2.Text);
            }

            if (this.OutputPRYM2textBox3.Text.Trim().Length == 0)
            {
                this.input.OutputFileNameList.Add("");
            }
            else
            {
                this.input.OutputFileNameList.Add(OutputPRYM2textBox3.Text);
            }
            if (this.OutputPRYM2textBox4.Text.Trim().Length == 0)
            {
                this.input.OutputFileNameList.Add("");
            }
            else
            {
                this.input.OutputFileNameList.Add(OutputPRYM2textBox4.Text);
            }

            if (this.OutputPRYM2textBox5.Text.Trim().Length == 0)
            {
                this.input.OutputFileNameList.Add("");
            }
            else
            {
                this.input.OutputFileNameList.Add(OutputPRYM2textBox5.Text);
            }

            

            if (flag != false)
            {
                
                Cursor.Current = Cursors.WaitCursor;

                if (!this.input.IsMultipleWelllog)
                {
                    this.input.Borehole = this.input.WellLog1.Borehole;
                    if (FSM.Calculate_PoissonRatio_YoungModulas_AnnieModel(this.input.Borehole, this.input.WellLog1, this.input.WellLog2, this.input.WellLog3, this.input.WellLog4, this.input.WellLog5, this.input.WellLog6, this.input.ReservoirTop, this.input.ReservoirBottom, this.input.ReservoirTopGiven, this.input.ReservoirBottomGiven, this.input.BiotConstant, this.input.PoreElasticConstant, this.input.MinHorStrain, this.input.MaxHorStrain, this.input.OutputFileNameList))
                    {
                        //PetrelLogger.InfoBox("Vertical & Horizontal Poisson Ratio and Young Modulus Was Calculated Successfully");
                    }
                    else
                    {
                        PetrelLogger.WarnBox("Sorry, Calculation Could not be completed, Please Try again");
                    }
                }
                else
                {
                    FSM.Calculate_PoissonRatio_YoungModulas_AnnieModel_MultipleWellLog(this.input);
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void PRYMAMdropTarget6_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv5 = dropped as WellLogVersion;
                if (this.input.Wlv5 != null)
                {
                    PRYMAMtextBox6.Text = this.input.Wlv5.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog5 = dropped as WellLog;
                if (this.input.WellLog5 != null)
                {
                    PRYMAMtextBox6.Text = this.input.WellLog5.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void PRYMAMdropTarget7_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv6 = dropped as WellLogVersion;
                if (this.input.Wlv6 != null)
                {
                    PRYMAMtextBox7.Text = this.input.Wlv6.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog6 = dropped as WellLog;
                if (this.input.WellLog6 != null)
                {
                    PRYMAMtextBox7.Text = this.input.WellLog6.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void PRYMAMcheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (this.PRYMAMcheckBox8.Checked)
            {
                this.PRYMAMtextBox8.Clear();
                PRYMAMtextBox8.Enabled = false;
                this.input.BiotConstantGiven = false;
                this.input.BiotConstant = 1;
            }
            else
            {
                PRYMAMtextBox8.Enabled = true;
                this.input.BiotConstantGiven = true;
            }
        }

        private void PRYMAMcheckBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (this.PRYMAMcheckBox11.Checked)
            {
                this.PRYMAMtextBox11.Clear();
                PRYMAMtextBox11.Enabled = false;
                this.input.MaxHorStrainGiven = false;
                this.input.MaxHorStrain = 0;
            }
            else
            {
                PRYMAMtextBox11.Enabled = true;
                this.input.MaxHorStrainGiven = true;
            }
        }

        private void PRYMAMcheckBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (this.PRYMAMcheckBox12.Checked)
            {
                this.PRYMAMtextBox12.Clear();
                PRYMAMtextBox12.Enabled = false;
                this.input.ReservoirTopGiven = false;
            }
            else
            {
                PRYMAMtextBox12.Enabled = true;
                this.input.ReservoirTopGiven = true;
            }
        }

        private void PRYMAMcheckBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (this.PRYMAMcheckBox13.Checked)
            {
                this.PRYMAMtextBox13.Clear();
                PRYMAMtextBox13.Enabled = false;
                this.input.ReservoirBottomGiven = false;
            }
            else
            {
                PRYMAMtextBox13.Enabled = true;
                this.input.ReservoirBottomGiven = true;
            }
        }

        private void PRYMtoolTipHotspot8_MouseHover(object sender, EventArgs e)
        {
            this.PRYMtoolTipPanel8.Visible = true;
            
        }

        private void PRYMtoolTipHotspot8_MouseLeave(object sender, EventArgs e)
        {
            this.PRYMtoolTipPanel8.Visible = false;
        }

        private void PRYMtoolTipHotspot9_MouseHover(object sender, EventArgs e)
        {
            this.PRYMtoolTipPanel9.Visible = true;
        }

        private void PRYMtoolTipHotspot9_MouseLeave(object sender, EventArgs e)
        {
            this.PRYMtoolTipPanel9.Visible = false;
        }

        private void PRYMtoolTipHotspot10_MouseHover(object sender, EventArgs e)
        {
            this.PRYMtoolTipPanel10.Visible = true;
        }

        private void PRYMtoolTipHotspot10_MouseLeave(object sender, EventArgs e)
        {
            this.PRYMtoolTipPanel10.Visible = false;
        }

        private void PRYMtoolTipHotspot11_MouseHover(object sender, EventArgs e)
        {
            this.PRYMtoolTipPanel11.Visible = true;
        }

        private void PRYMtoolTipHotspot11_MouseLeave(object sender, EventArgs e)
        {
            this.PRYMtoolTipPanel11.Visible = false;
        }

        private void PRYMtoolTipHotspot12_MouseHover(object sender, EventArgs e)
        {
            this.PRYMtoolTipPanel12.Visible = true;
        }

        private void PRYMtoolTipHotspot12_MouseLeave(object sender, EventArgs e)
        {
            this.PRYMtoolTipPanel12.Visible = false;
        }

        private void PRYMtoolTipHotspot13_MouseHover(object sender, EventArgs e)
        {
            this.PRYMtoolTipPanel13.Visible = true;
        }

        private void PRYMtoolTipHotspot13_MouseLeave(object sender, EventArgs e)
        {
            this.PRYMtoolTipPanel13.Visible = false;
        }

        private void PRYMtoolTipHotspot1_MouseHover(object sender, EventArgs e)
        {
            this.PRYMtoolTipPanel8.Visible = true;
        }

        private void PRYMtoolTipHotspot1_MouseLeave(object sender, EventArgs e)
        {
            this.PRYMtoolTipPanel8.Visible = false;
        }

        private void PRYMtoolTipHotspot2_MouseHover(object sender, EventArgs e)
        {
            this.PRYMtoolTipPanel9.Visible = true;
        }

        private void PRYMtoolTipHotspot2_MouseLeave(object sender, EventArgs e)
        {
            this.PRYMtoolTipPanel9.Visible = false;
        }

        #endregion

        #region PRYM2


        private void PRYM2Cancelbutton_Click(object sender, EventArgs e)
        {
            this.PRYM2textBox1.Clear();
            this.PRYM2textBox2.Clear();
            this.PRYM2textBox3.Clear();
            this.PRYM2textBox4.Clear();
            this.PRYM2textBox5.Clear();
            this.PRYM2textBox6.Clear();
            this.PRYM2textBox7.Clear();
            this.PRYM2textBox8.Clear();
            this.PRYM2textBox9.Clear();
            this.PRYM2textBox10.Clear();
            this.PRYM2textBox11.Clear();
            this.PRYM2textBox12.Clear();
            this.PRYM2textBox13.Clear();
            this.PRYM2textBox14.Clear();

            this.PRYM2checkBox7.Checked = false;
            this.PRYM2checkBox8.Checked = false;
            this.PRYM2checkBox9.Checked = false;
            this.PRYM2checkBox10.Checked = false;
            this.PRYM2checkBox11.Checked = false;
            this.PRYM2checkBox12.Checked = false;
            this.PRYM2checkBox13.Checked = false;
            this.PRYM2checkBox14.Checked = false;
        }

        private void PRYM2Calculatebutton_Click(object sender, EventArgs e)
        {
            FracScopeModel FSM = new FracScopeModel();
            Boolean flag = true;
            //PetrelLogger.InfoBox(this.input.WellLog1.Name);

            if (this.PRYM2textBox1.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("P Wave Sonic Log (Vertical) is not specified");
                return;
            }
            if (this.PRYM2textBox2.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("S Wave Sonic Log (Vertical) is not specified");
                return;
            }

            if (this.PRYM2textBox3.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("S Wave Sonic Log (Horizontal) is not specified");
                return;
            }
            if (this.PRYM2textBox4.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Density Log is not specified");
                return;
            }

            if (this.PRYM2textBox5.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Vertical Stress Log is not specified");
                return;
            }

            if (this.PRYM2textBox6.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Pore Pressure Log is not specified");
                return;
            }

            if (!this.PRYM2checkBox7.Checked)
            {
                if (this.PRYM2textBox7.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Constant 1 is not specified");
                    return;
                }
                else
                {
                    this.input.Constant1 = (float)(Convert.ToDouble(this.PRYM2textBox7.Text));
                }
            }

            if (!this.PRYM2checkBox8.Checked)
            {
                if (this.PRYM2textBox8.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Constant 1 is not specified");
                    return;
                }
                else
                {
                    this.input.Constant2 = (float)(Convert.ToDouble(this.PRYM2textBox8.Text));
                }
            }

            if (!this.PRYM2checkBox9.Checked)
            {
                if (this.PRYM2textBox9.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Biot Constant is not specified");
                    return;
                }
                else
                {
                    this.input.BiotConstant = (float)(Convert.ToDouble(this.PRYM2textBox9.Text));
                }
            }

            if (!PRYM2checkBox10.Checked)
            {
                if (this.PRYM2textBox10.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Pore Elastic Constant is not specified");
                    return;
                }
                else
                {
                    this.input.PoreElasticConstant = (float)(Convert.ToDouble(this.PRYM2textBox10.Text));
                }
            }

            if (!this.PRYM2checkBox11.Checked)
            {
                if (this.PRYM2textBox11.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Min Horizontal Strain is not specified");
                    return;
                }
                else
                {
                    this.input.MinHorStrain = (float)(Convert.ToDouble(this.PRYM2textBox11.Text));
                }
            }

            if (!this.PRYM2checkBox12.Checked)
            {
                if (this.PRYM2textBox12.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Max Horizontal Strain is not specified");
                    return;
                }
                else
                {
                    this.input.MaxHorStrain = (float)(Convert.ToDouble(this.PRYM2textBox12.Text));
                }
            }

            if (this.input.ReservoirTopGiven)
            {
                if (this.PRYM2textBox13.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Top is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirTop = FSM.PS_ConvertFromUI(Convert.ToDouble(this.PRYM2textBox13.Text));
                }
            }
            if (this.input.ReservoirBottomGiven)
            {
                if (this.PRYM2textBox14.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Bottom is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirBottom = FSM.PS_ConvertFromUI(Convert.ToDouble(this.PRYM2textBox14.Text));
                }
            }

            if (this.OutputPRYM2textBox1.Text.Trim().Length == 0)
            {
                this.input.OutputFileNameList.Add("");
            }
            else
            {
                this.input.OutputFileNameList.Add(OutputPRYM2textBox1.Text);
            }
            if (this.OutputPRYM2textBox2.Text.Trim().Length == 0)
            {
                this.input.OutputFileNameList.Add("");
            }
            else
            {
                this.input.OutputFileNameList.Add(OutputPRYM2textBox2.Text);
            }

            if (this.OutputPRYM2textBox3.Text.Trim().Length == 0)
            {
                this.input.OutputFileNameList.Add("");
            }
            else
            {
                this.input.OutputFileNameList.Add(OutputPRYM2textBox3.Text);
            }
            if (this.OutputPRYM2textBox4.Text.Trim().Length == 0)
            {
                this.input.OutputFileNameList.Add("");
            }
            else
            {
                this.input.OutputFileNameList.Add(OutputPRYM2textBox4.Text);
            }

            if (this.OutputPRYM2textBox5.Text.Trim().Length == 0)
            {
                this.input.OutputFileNameList.Add("");
            }
            else
            {
                this.input.OutputFileNameList.Add(OutputPRYM2textBox5.Text);
            }



            if (flag != false)
            {
                
                Cursor.Current = Cursors.WaitCursor;

                if (!this.input.IsMultipleWelllog)
                {
                    this.input.Borehole = this.input.WellLog1.Borehole;
                    if (FSM.Calculate_PoissonRatio_YoungModulas_Modified_AnnieModel(this.input.Borehole, this.input.WellLog1, this.input.WellLog2, this.input.WellLog3, this.input.WellLog4, this.input.WellLog5, this.input.WellLog6, this.input.ReservoirTop, this.input.ReservoirBottom, this.input.ReservoirTopGiven, this.input.ReservoirBottomGiven, this.input.Constant1, this.input.Constant2,this.input.BiotConstant, this.input.PoreElasticConstant, this.input.MinHorStrain, this.input.MaxHorStrain, this.input.OutputFileNameList))
                    {
                        //PetrelLogger.InfoBox("Vertical & Horizontal Poisson Ratio and Young Modulus Was Calculated Successfully");
                    }
                    else
                    {
                        PetrelLogger.WarnBox("Sorry, Calculation Could not be completed, Please Try again");
                    }
                }
                else
                {
                    FSM.Calculate_PoissonRatio_YoungModulas_Modified_AnnieModel_MultipleWellLog(this.input);
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void PRYM2dropTarget1_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv1 = dropped as WellLogVersion;
                if (this.input.Wlv1 != null)
                {
                    PRYM2textBox1.Text = this.input.Wlv1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog1 = dropped as WellLog;
                if (this.input.WellLog1 != null)
                {
                    PRYM2textBox1.Text = this.input.WellLog1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void PRYM2dropTarget2_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv2 = dropped as WellLogVersion;
                if (this.input.Wlv2 != null)
                {
                    PRYM2textBox2.Text = this.input.Wlv2.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog2 = dropped as WellLog;
                if (this.input.WellLog2 != null)
                {
                    PRYM2textBox2.Text = this.input.WellLog2.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void PRYM2dropTarget3_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv3 = dropped as WellLogVersion;
                if (this.input.Wlv3 != null)
                {
                    PRYM2textBox3.Text = this.input.Wlv3.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog3 = dropped as WellLog;
                if (this.input.WellLog3 != null)
                {
                    PRYM2textBox3.Text = this.input.WellLog3.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void PRYM2dropTarget4_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv4 = dropped as WellLogVersion;
                if (this.input.Wlv4 != null)
                {
                    PRYM2textBox4.Text = this.input.Wlv4.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog4 = dropped as WellLog;
                if (this.input.WellLog4 != null)
                {
                    PRYM2textBox4.Text = this.input.WellLog4.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void PRYM2dropTarget5_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv5 = dropped as WellLogVersion;
                if (this.input.Wlv5 != null)
                {
                    PRYM2textBox5.Text = this.input.Wlv5.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog5 = dropped as WellLog;
                if (this.input.WellLog5 != null)
                {
                    PRYM2textBox5.Text = this.input.WellLog5.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void PRYM2dropTarget6_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv6 = dropped as WellLogVersion;
                if (this.input.Wlv6 != null)
                {
                    PRYM2textBox6.Text = this.input.Wlv6.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog6 = dropped as WellLog;
                if (this.input.WellLog6 != null)
                {
                    PRYM2textBox6.Text = this.input.WellLog6.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void PRYM2checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (PRYM2checkBox7.Checked)
            {
                PRYM2textBox7.Clear();
                PRYM2textBox7.Enabled = false;
                this.input.Constant2Given = false;
                this.input.Constant1 = (float)1.12;
            }
            else
            {
                PRYM2textBox7.Enabled = true;
                this.input.Constant2Given = true;
            }
        }

        private void PRYM2checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (PRYM2checkBox8.Checked)
            {
                PRYM2textBox8.Clear();
                PRYM2textBox8.Enabled = false;
                this.input.Constant1Given = false;
                this.input.Constant2 = (float)0.76;
            }
            else
            {
                PRYM2textBox8.Enabled = true;
                this.input.Constant1Given = true;
            }
        }

        private void PRYM2checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (PRYM2checkBox9.Checked)
            {
                PRYM2textBox9.Clear();
                PRYM2textBox9.Enabled = false;
                this.input.BiotConstantGiven = false;
                this.input.BiotConstant = 1;
            }
            else
            {
                PRYM2textBox9.Enabled = true;
                this.input.BiotConstantGiven = true;
            }
        }

        private void PRYM2checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (PRYM2checkBox10.Checked)
            {
                PRYM2textBox10.Clear();
                PRYM2textBox10.Enabled = false;
                this.input.PoreElasticConstantGiven = false;
                this.input.PoreElasticConstant = 0;
            }
            else
            {
                PRYM2textBox10.Enabled = true;
                this.input.PoreElasticConstantGiven = true;
            }
        }

        private void PRYM2checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (PRYM2checkBox11.Checked)
            {
                PRYM2textBox11.Clear();
                PRYM2textBox11.Enabled = false;
                this.input.MinHorStrainGiven = false;
                this.input.MinHorStrain = 0;
            }
            else
            {
                PRYM2textBox11.Enabled = true;
                this.input.MinHorStrainGiven = true;
            }
        }

        private void PRYM2checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (PRYM2checkBox12.Checked)
            {
                PRYM2textBox12.Clear();
                PRYM2textBox12.Enabled = false;
                this.input.MaxHorStrainGiven = false;
                this.input.MaxHorStrain = 0;
            }
            else
            {
                PRYM2textBox12.Enabled = true;
                this.input.MaxHorStrainGiven = true;
            }
        }

        private void PRYM2checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (PRYM2checkBox13.Checked)
            {
                PRYM2textBox13.Clear();
                PRYM2textBox13.Enabled = false;
                this.input.ReservoirTopGiven = false;
            }
            else
            {
                PRYM2textBox13.Enabled = true;
                this.input.ReservoirTopGiven = true;
            }
        }

        private void PRYM2checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (PRYM2checkBox14.Checked)
            {
                PRYM2textBox14.Clear();
                PRYM2textBox14.Enabled = false;
                this.input.ReservoirBottomGiven = false;
            }
            else
            {
                PRYM2textBox14.Enabled = true;
                this.input.ReservoirBottomGiven = true;
            }
        }

        private void PRYM2toolTipHotspot7_MouseHover(object sender, EventArgs e)
        {
            this.PRYM2toolTipPanel7.Visible = true;
        }

        private void PRYM2toolTipHotspot7_MouseLeave(object sender, EventArgs e)
        {
            this.PRYM2toolTipPanel7.Visible = false;
        }

        private void PRYM2toolTipHotspot8_MouseHover(object sender, EventArgs e)
        {
            this.PRYM2toolTipPanel8.Visible = true;
        }

        private void PRYM2toolTipHotspot8_MouseLeave(object sender, EventArgs e)
        {
            this.PRYM2toolTipPanel8.Visible = false;
        }

        private void PRYM2toolTipHotspot9_MouseHover(object sender, EventArgs e)
        {
            this.PRYM2toolTipPanel9.Visible = true;
        }

        private void PRYM2toolTipHotspot9_MouseLeave(object sender, EventArgs e)
        {
            this.PRYM2toolTipPanel9.Visible = false;
        }

        private void PRYM2toolTipHotspot10_MouseHover(object sender, EventArgs e)
        {
            this.PRYM2toolTipPanel10.Visible = true;
        }

        private void PRYM2toolTipHotspot10_MouseLeave(object sender, EventArgs e)
        {
            this.PRYM2toolTipPanel10.Visible = false;
        }

        private void PRYM2toolTipHotspot11_MouseHover(object sender, EventArgs e)
        {
            this.PRYM2toolTipPanel11.Visible = true;
        }

        private void PRYM2toolTipHotspot11_MouseLeave(object sender, EventArgs e)
        {
            this.PRYM2toolTipPanel11.Visible = false;
        }

        private void PRYM2toolTipHotspot12_MouseHover(object sender, EventArgs e)
        {
            this.PRYM2toolTipPanel12.Visible = true;
        }

        private void PRYM2toolTipHotspot12_MouseLeave(object sender, EventArgs e)
        {
            this.PRYM2toolTipPanel12.Visible = false;
        }

        private void PRYM2toolTipHotspot13_MouseHover(object sender, EventArgs e)
        {
            this.PRYM2toolTipPanel13.Visible = true;
        }

        private void PRYM2toolTipHotspot13_MouseLeave(object sender, EventArgs e)
        {
            this.PRYM2toolTipPanel13.Visible = false;
        }

        private void PRYM2toolTipHotspot14_MouseHover(object sender, EventArgs e)
        {
            this.PRYM2toolTipPanel14.Visible = true;
        }

        private void PRYM2toolTipHotspot14_MouseLeave(object sender, EventArgs e)
        {
            this.PRYM2toolTipPanel14.Visible = false;
        }

        #endregion

        #region VS

        private void VSdropTarget1_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv1 = dropped as WellLogVersion;
                if (this.input.Wlv1 != null)
                {
                    VStextBox1.Text = this.input.Wlv1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog1 = dropped as WellLog;
                if (this.input.WellLog1 != null)
                {
                    VStextBox1.Text = this.input.WellLog1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void VScheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (VScheckBox2.Checked)
            {
                VStextBox2.Clear();
                VStextBox2.Enabled = false;
                this.input.WaterDepthGiven = true;
                this.input.WaterDepth = 0;
            }
            else
            {
                VStextBox2.Enabled = true;
                this.input.WaterDepthGiven = false;
            }
        }

        private void VStoolTipHotspot1_MouseHover(object sender, EventArgs e)
        {
            this.VStoolTipPanel1.Visible = true;
        }

        private void VStoolTipHotspot1_MouseLeave(object sender, EventArgs e)
        {
            this.VStoolTipPanel1.Visible = false;
        }

        private void VSCancelbutton_Click(object sender, EventArgs e)
        {
            this.VStextBox1.Clear();
            this.VStextBox2.Clear();
            this.VScheckBox2.Checked = false;
        }

        private void VSCalculatebutton_Click(object sender, EventArgs e)
        {
            FracScopeModel FSM = new FracScopeModel();
            Boolean flag = true;
            //PetrelLogger.InfoBox(this.input.WellLog1.Name);

            if (this.VStextBox1.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Density Log is not specified");
                return;
            }
            if (!this.VScheckBox2.Checked)
            {
                if (this.VStextBox2.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Water Depth is not specified");
                    return;
                }
                else
                {
                    this.input.WaterDepth = (float)(Convert.ToDouble(this.VStextBox2.Text));
                }
            }
           


            if (this.tpGEOutputtextBox.Text.Trim().Length == 0)
            {
                this.input.OutputFileName = "";
            }
            else
            {
                this.input.OutputFileName = tpGEOutputtextBox.Text;
            }

            if (flag != false)
            {
                
                this.input.ReservoirTopGiven = false;
                this.input.ReservoirBottomGiven = false;

                Cursor.Current = Cursors.WaitCursor;

                if (!this.input.IsMultipleWelllog)
                {
                    this.input.Borehole = this.input.WellLog1.Borehole;
                    if (FSM.Calculate_VerticalStress(this.input.Borehole, this.input.WellLog1,  this.input.ReservoirTop, this.input.ReservoirBottom, this.input.ReservoirTopGiven, this.input.ReservoirBottomGiven, this.input.WaterDepth,  this.input.OutputFileName))
                    {
                        //PetrelLogger.InfoBox("Vertical & Horizontal Poisson Ratio and Young Modulus Was Calculated Successfully");
                    }
                    else
                    {
                        PetrelLogger.WarnBox("Sorry, Calculation Could not be completed, Please Try again");
                    }
                }
                else
                {
                    FSM.Calculate_VerticalStress_MultipleWellLog(this.input);
                }
                Cursor.Current = Cursors.Default;
            }
        }

        #endregion

        #region YM

        private void YMdropTarget2_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv1 = dropped as WellLogVersion;
                if (this.input.Wlv1 != null)
                {
                    YMtextBox2.Text = this.input.Wlv1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog1 = dropped as WellLog;
                if (this.input.WellLog1 != null)
                {
                    YMtextBox2.Text = this.input.WellLog1.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void YMdropTarget3_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv2 = dropped as WellLogVersion;
                if (this.input.Wlv2 != null)
                {
                    YMtextBox3.Text = this.input.Wlv2.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog2 = dropped as WellLog;
                if (this.input.WellLog2 != null)
                {
                    YMtextBox3.Text = this.input.WellLog2.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void YMdropTarget4_DragDrop(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            if (this.input.IsMultipleWelllog)
            {
                this.input.Wlv3 = dropped as WellLogVersion;
                if (this.input.Wlv3 != null)
                {
                    YMtextBox4.Text = this.input.Wlv3.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Global Well Log");
                }
            }

            else
            {
                this.input.WellLog3 = dropped as WellLog;
                if (this.input.WellLog3 != null)
                {
                    YMtextBox4.Text = this.input.WellLog3.Name;
                }
                else
                {
                    PetrelLogger.WarnBox("Object must be a Well Log");
                }
            }
        }

        private void YMcheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (YMcheckBox1.Checked)
            {
                YMtextBox5.Clear();
                YMtextBox5.Enabled = false;
                this.input.ReservoirTopGiven = false;
            }
            else
            {
                YMtextBox5.Enabled = true;
                this.input.ReservoirTopGiven = true;
            }
        }

        private void YMcheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (YMcheckBox2.Checked)
            {
                YMtextBox6.Clear();
                YMtextBox6.Enabled = false;
                this.input.ReservoirBottomGiven = false;
            }
            else
            {
                YMtextBox6.Enabled = true;
                this.input.ReservoirBottomGiven = true;
            }
        }

        private void YMCancelbutton_Click(object sender, EventArgs e)
        {
            this.YMtextBox2.Clear();
            this.YMtextBox3.Clear();
            this.YMtextBox4.Clear();
            this.YMtextBox5.Clear();
            this.YMtextBox6.Clear();
            this.YMcheckBox1.Checked = false;
            this.YMcheckBox2.Checked = false;
        }

        private void YMCalculatebutton_Click(object sender, EventArgs e)
        {
            FracScopeModel FSM = new FracScopeModel();
            Boolean flag = true;
            //PetrelLogger.InfoBox(this.input.WellLog1.Name);

            if (this.YMtextBox2.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("P Wave Sonic Log is not specified");
                return;
            }
            if (this.YMtextBox3.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("S Wave Sonic Log is not specified");
                return;
            }
            if (this.YMtextBox4.Text.Trim().Length == 0)
            {
                flag = false;
                PetrelLogger.WarnBox("Density Log is not specified");
                return;
            }
            if (this.input.ReservoirTopGiven)
            {
                if (this.YMtextBox5.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Top is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirTop = FSM.PS_ConvertFromUI(Convert.ToDouble(YMtextBox5.Text));
                }
            }
            if (this.input.ReservoirBottomGiven)
            {
                if (this.YMtextBox6.Text.Trim().Length == 0)
                {
                    flag = false;
                    PetrelLogger.WarnBox("Reservoir Bottom is not specified");
                    return;
                }
                else
                {
                    this.input.ReservoirBottom = FSM.PS_ConvertFromUI(Convert.ToDouble(YMtextBox6.Text));
                }
            }

            if (this.tpGEOutputtextBox.Text.Trim().Length == 0)
            {
                this.input.OutputFileName = "";
            }
            else
            {
                this.input.OutputFileName = tpGEOutputtextBox.Text;
            }

            if (flag != false)
            {
                
                Cursor.Current = Cursors.WaitCursor;

                if (!this.input.IsMultipleWelllog)
                {
                    this.input.Borehole = this.input.WellLog1.Borehole;
                    if (FSM.Calculate_YoungModulas(this.input.Borehole, this.input.WellLog1, this.input.WellLog2, this.input.WellLog3, this.input.ReservoirTop, this.input.ReservoirBottom, this.input.ReservoirTopGiven, this.input.ReservoirBottomGiven, this.input.OutputFileName))
                    {
                        //PetrelLogger.InfoBox("Young Modulus Was Calculated Successfully");

                    }
                    else
                    {
                        PetrelLogger.WarnBox("Sorry, Calculation Could not be completed, Please Try again");
                    }
                }
                else
                {
                    FSM.Calculate_YoungModulas_MultipleWellLog(this.input);
                }
                Cursor.Current = Cursors.Default;
            }

        }

        private void YMtoolTipHotspot1_MouseHover(object sender, EventArgs e)
        {
            this.YMtoolTipPanel1.Visible = true;
        }

        private void YMtoolTipHotspot1_MouseLeave(object sender, EventArgs e)
        {
            this.YMtoolTipPanel1.Visible = false;
        }

        private void YMtoolTipHotspot2_MouseHover(object sender, EventArgs e)
        {
            this.YMtoolTipPanel2.Visible = true;
        }

        private void YMtoolTipHotspot2_MouseLeave(object sender, EventArgs e)
        {
            this.YMtoolTipPanel2.Visible = false;
        }

        #endregion




        #region Tab page GP

        private void TC1GPcomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.TC1GPcomboBox1.SelectedIndex == 0)
            {
                this.Form_Clear();
                this.groups_Invisible();
                //this.BlankGB.Location = new Point(126, 136);
                //this.BlankGB.Visible = true;
            }

            else if (TC1GPcomboBox1.SelectedIndex == 1)
            {
                this.Form_Clear();
                this.groups_Invisible();
                this.ClayPorosityGB.Location = new Point(6, 21);
                this.ClayPorosityGB.Visible = true;
            }
            else if (TC1GPcomboBox1.SelectedIndex == 2)
            {
                this.Form_Clear();
                this.groups_Invisible();
                this.DensityPorosityGB.Location = new Point(6, 21);
                this.DensityPorosityGB.Visible = true;
            }
            else if (TC1GPcomboBox1.SelectedIndex == 3)
            {
                this.Form_Clear();
                this.groups_Invisible();
                this.FracturePorosityGB.Location = new Point(6, 21);
                this.FracturePorosityGB.Visible = true;
            }
            else if (TC1GPcomboBox1.SelectedIndex == 4)
            {
                this.Form_Clear();
                this.groups_Invisible();
                this.OrganicPorosityGB.Location = new Point(6, 21);
                this.OrganicPorosityGB.Visible = true;
            }
            else if (TC1GPcomboBox1.SelectedIndex == 5)
            {
                this.Form_Clear();
                this.groups_Invisible();
                this.SandPorosityGB.Location = new Point(6, 21);
                this.SandPorosityGB.Visible = true;
            }
            else if (TC1GPcomboBox1.SelectedIndex == 6)
            {
                this.Form_Clear();
                this.groups_Invisible();
                this.TotalOrganicPorosityGB.Location = new Point(6, 21);
                this.TotalOrganicPorosityGB.Visible = true;
            }
            else if (TC1GPcomboBox1.SelectedIndex == 7)
            {
                this.Form_Clear();
                this.groups_Invisible();
                this.TOC2_GB.Location = new Point(6, 21);
                this.TOC2_GB.Visible = true;
            }

            else if (TC1GPcomboBox1.SelectedIndex == 8)
            {
                this.Form_Clear();
                this.groups_Invisible();
                this.VolumeOfShaleGB.Location = new Point(6, 21);
                this.VolumeOfShaleGB.Visible = true;
            }

        }

        private void tcGP_Cancelbutton_Click(object sender, EventArgs e)
        {
            this.tpGPOutputtextBox.Clear();

            if (this.TC1GPcomboBox1.SelectedIndex == 1)      CPCancelbutton_Click(sender, e);
            else if (this.TC1GPcomboBox1.SelectedIndex == 2) DPCancelbutton_Click(sender, e);
            else if (this.TC1GPcomboBox1.SelectedIndex == 3) FPCancelbutton_Click(sender, e);
            else if (this.TC1GPcomboBox1.SelectedIndex == 4) OPCancelbutton_Click(sender, e);
            else if (this.TC1GPcomboBox1.SelectedIndex == 5) SPCancelbutton_Click(sender, e);
            else if (this.TC1GPcomboBox1.SelectedIndex == 6) TOP_Cancelbutton_Click(sender, e);
            else if (this.TC1GPcomboBox1.SelectedIndex == 7) TOC2Cancelbutton_Click(sender, e);
            else if (this.TC1GPcomboBox1.SelectedIndex == 8) VSHCancelbutton2_Click(sender, e);



        }

        private void tcGP_Calculatebutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.TC1GPcomboBox1.SelectedIndex == 1) CPCalculatebutton_Click(sender, e);
                else if (this.TC1GPcomboBox1.SelectedIndex == 2) DPCalculatebutton_Click(sender, e);
                else if (this.TC1GPcomboBox1.SelectedIndex == 3) FPCalculatebutton_Click(sender, e);
                else if (this.TC1GPcomboBox1.SelectedIndex == 4) OPCalculatebutton_Click(sender, e);
                else if (this.TC1GPcomboBox1.SelectedIndex == 5) SPCalculatebutton_Click(sender, e);
                else if (this.TC1GPcomboBox1.SelectedIndex == 6) TOPCalculatebutton_Click(sender, e);
                else if (this.TC1GPcomboBox1.SelectedIndex == 7) TOC2Calculatebutton_Click(sender, e);
                else if (this.TC1GPcomboBox1.SelectedIndex == 8) VSHCalculate_Click(sender, e);
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return;
                throw;
            }
        }

        private void TC1GPcheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (TC1GPcheckBox1.Checked)
            {
                this.input.IsMultipleWelllog = true;
            }
            else
            {
                this.input.IsMultipleWelllog = false;
            }
        }

        private void TC1GPtoolTipHotspot1_MouseHover(object sender, EventArgs e)
        {
            this.TC1GPtoolTipPanel1.Visible = true;
        }

        private void TC1GPtoolTipHotspot1_MouseLeave(object sender, EventArgs e)
        {
            this.TC1GPtoolTipPanel1.Visible = false;
        }


        private void tpGPOutputtoolTipHotspot_MouseHover(object sender, EventArgs e)
        {
            this.tpGPOutputtoolTipPanel.Visible = true;
        }

        private void tpGPOutputtoolTipHotspot_MouseLeave(object sender, EventArgs e)
        {
            this.tpGPOutputtoolTipPanel.Visible = false;
        }

        #endregion

        #region Tab page GE
        private void TC1GEcomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.TC1GEcomboBox1.SelectedIndex == 0)
            {
                this.Form_Clear();
                this.groups_Invisible();
                //this.BlankGB.Location = new Point(126, 136);
                //this.BlankGB.Visible = true;
            }

            else if (TC1GEcomboBox1.SelectedIndex == 1)
            {
                this.Form_Clear();
                this.groups_Invisible();
                this.AzimuthalAnisotropyGB.Location = new Point(6, 21);
                this.AzimuthalAnisotropyGB.Visible = true;
                this.tpGEOutputGB.Visible = true;
            }
            else if (TC1GEcomboBox1.SelectedIndex == 2)
            {
                this.Form_Clear();
                this.groups_Invisible();
                this.BrittlenessIndexGB.Location = new Point(6, 21);
                this.BrittlenessIndexGB.Visible = true;
                this.tpGEOutputGB.Visible = true;
            }
            else if (TC1GEcomboBox1.SelectedIndex == 3)
            {
                this.Form_Clear();
                this.groups_Invisible();
                this.EpsilonGB.Location = new Point(6, 21);
                this.EpsilonGB.Visible = true;
                this.tpGEOutputGB.Visible = true;
            }
            else if (TC1GEcomboBox1.SelectedIndex == 4)
            {
                this.Form_Clear();
                this.groups_Invisible();
                this.GammaGB.Location = new Point(6, 21);
                this.GammaGB.Visible = true;
                this.tpGEOutputGB.Visible = true;
            }
            else if (TC1GEcomboBox1.SelectedIndex == 5)
            {
                this.Form_Clear();
                this.groups_Invisible();
                this.MinHorStress_GB.Location = new Point(6, 21);
                this.MinHorStress_GB.Visible = true;
                this.tpGEOutputGB.Visible = true;
            }
            else if (TC1GEcomboBox1.SelectedIndex == 6)
            {
                this.Form_Clear();
                this.groups_Invisible();
                this.PoissonRatioGB.Location = new Point(6, 21);
                this.PoissonRatioGB.Visible = true;
                this.tpGEOutputGB.Visible = true;
            }
            else if (TC1GEcomboBox1.SelectedIndex == 7)
            {
                this.Form_Clear();
                this.groups_Invisible();
                this.PRYMAM_GB.Location = new Point(6, 21);
                this.PRYMAM_GB.Visible = true;
                this.tpGEOutputPRYM_GB.Visible = true;
            }
            else if (TC1GEcomboBox1.SelectedIndex == 8)
            {
                this.Form_Clear();
                this.groups_Invisible();
                this.PRYM2_GB.Location = new Point(6, 21);
                this.PRYM2_GB.Visible = true;
                this.tpGEOutputPRYM_GB.Visible = true;
            }
            else if (TC1GEcomboBox1.SelectedIndex == 9)
            {
                this.Form_Clear();
                this.groups_Invisible();
                this.VerticalStress_GB.Location = new Point(6, 21);
                this.VerticalStress_GB.Visible = true;
                this.tpGEOutputGB.Visible = true;
            }
            else if (TC1GEcomboBox1.SelectedIndex == 10)
            {
                this.Form_Clear();
                this.groups_Invisible();
                this.YoungModulusGB.Location = new Point(6, 21);
                this.YoungModulusGB.Visible = true;
                this.tpGEOutputGB.Visible = true;
            }
        }

        private void tcGE_Cancelbutton_Click(object sender, EventArgs e)
        {

            if (this.TC1GEcomboBox1.SelectedIndex == 1)     { AACancelbutton_Click(sender, e);  this.tpGPOutputtextBox.Clear(); }
            else if (this.TC1GEcomboBox1.SelectedIndex == 2) { BICancelbutton_Click(sender, e); this.tpGPOutputtextBox.Clear(); }
            else if (this.TC1GEcomboBox1.SelectedIndex == 3) {ECancelbutton_Click(sender, e);   this.tpGPOutputtextBox.Clear(); }
            else if (this.TC1GEcomboBox1.SelectedIndex == 4) {GCancelbutton_Click(sender, e);   this.tpGPOutputtextBox.Clear(); }
            else if (this.TC1GEcomboBox1.SelectedIndex == 5) {MHSCancelbutton_Click(sender, e); this.tpGPOutputtextBox.Clear(); }
            else if (this.TC1GEcomboBox1.SelectedIndex == 6) {PRCancelbutton_Click(sender, e);  this.tpGPOutputtextBox.Clear(); }
            else if (this.TC1GEcomboBox1.SelectedIndex == 7) {PRYMAMCancelbutton_Click(sender, e);   this.OutputPRYM2textBox1.Clear();}
            else if (this.TC1GEcomboBox1.SelectedIndex == 8) {PRYM2Cancelbutton_Click(sender, e);    this.OutputPRYM2textBox1.Clear();}
            else if (this.TC1GEcomboBox1.SelectedIndex == 9) {VSCancelbutton_Click(sender, e);  this.tpGPOutputtextBox.Clear(); }
            else if (this.TC1GEcomboBox1.SelectedIndex == 10) {YMCancelbutton_Click(sender, e); this.tpGPOutputtextBox.Clear(); }
        }

        private void tcGE_Calculatebutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.TC1GEcomboBox1.SelectedIndex == 1) AACalculatebutton_Click(sender, e);
                else if (this.TC1GEcomboBox1.SelectedIndex == 2) BICalculatebutton_Click(sender, e);
                else if (this.TC1GEcomboBox1.SelectedIndex == 3) ECalculatebutton_Click(sender, e);
                else if (this.TC1GEcomboBox1.SelectedIndex == 4) GCalculatebutton_Click(sender, e);
                else if (this.TC1GEcomboBox1.SelectedIndex == 5) MHSCalculatebutton_Click(sender, e);
                else if (this.TC1GEcomboBox1.SelectedIndex == 6) PRCalculatebutton_Click(sender, e);
                else if (this.TC1GEcomboBox1.SelectedIndex == 7) PRYMAMCalculatebutton_Click(sender, e);
                else if (this.TC1GEcomboBox1.SelectedIndex == 8) PRYM2Calculatebutton_Click(sender, e);
                else if (this.TC1GEcomboBox1.SelectedIndex == 9) VSCalculatebutton_Click(sender, e);
                else if (this.TC1GEcomboBox1.SelectedIndex == 10) YMCalculatebutton_Click(sender, e);
            }
            catch (Exception ex)
            {
                PetrelLogger.WarnBox("Sorry An Error has Occured", ex);
                return ;
                throw;
            }
        }

        private void TC1GEcheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (TC1GEcheckBox1.Checked)
            {
                this.input.IsMultipleWelllog = true;
            }
            else
            {
                this.input.IsMultipleWelllog = false;
            }
        }

        private void TC1GEtoolTipHotspot1_MouseHover(object sender, EventArgs e)
        {
            this.TC1GEtoolTipPanel1.Visible = true;
        }

        private void TC1GEtoolTipHotspot1_MouseLeave(object sender, EventArgs e)
        {
            this.TC1GEtoolTipPanel1.Visible = false;
        }

        private void OutputtoolTipHotspot1_MouseHover(object sender, EventArgs e)
        {
            this.tpGEOutputtoolTipPanel.Visible = true;
        }
        
        private void OutPuttoolTipHotspot1_MouseLeave(object sender, EventArgs e)
        {
            this.tpGEOutputtoolTipPanel.Visible = false;
        }

        private void OutputPRYM2toolTipHotspot1_MouseHover(object sender, EventArgs e)
        {
            this.OutputPRYM2toolTipPanel1.Visible = true;
        }

        private void OutputPRYM2toolTipHotspot1_MouseLeave(object sender, EventArgs e)
        {
            this.OutputPRYM2toolTipPanel1.Visible = false;
        }
        #endregion

        #region not in use
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChooseFunctionalitycomboBox.SelectedIndex == 0)
            {
                this.Form_Clear();
                this.groups_Invisible();
                this.BlankGB.Location = new Point(126, 136);
                this.BlankGB.Visible = true;
            }

            else if (ChooseFunctionalitycomboBox.SelectedIndex == 1)
            {
                this.Form_Clear();
                this.groups_Invisible();
                this.AzimuthalAnisotropyGB.Location = new Point(80, 136);
                this.AzimuthalAnisotropyGB.Visible = true;
            }

            else if (ChooseFunctionalitycomboBox.SelectedIndex == 2)
            {
                this.Form_Clear();
                this.groups_Invisible();
                this.BrittlenessIndexGB.Location = new Point(80, 136);
                this.BrittlenessIndexGB.Visible = true;
            }
            else if (ChooseFunctionalitycomboBox.SelectedIndex == 3)
            {
                this.Form_Clear();
                this.groups_Invisible();
                this.ClayPorosityGB.Location = new Point(80, 136);
                this.ClayPorosityGB.Visible = true;
            }
            else if (ChooseFunctionalitycomboBox.SelectedIndex == 4)
            {
                this.Form_Clear();
                this.groups_Invisible();
                this.DensityPorosityGB.Location = new Point(80, 136);
                this.DensityPorosityGB.Visible = true;
            }
            else if (ChooseFunctionalitycomboBox.SelectedIndex == 5)
            {
                this.Form_Clear();
                this.groups_Invisible();
                this.EpsilonGB.Location = new Point(80, 136);
                this.EpsilonGB.Visible = true;
            }
            else if (ChooseFunctionalitycomboBox.SelectedIndex == 6)
            {
                this.Form_Clear();
                this.groups_Invisible();
                this.GammaGB.Location = new Point(80, 136);
                this.GammaGB.Visible = true;
            }
            else if (ChooseFunctionalitycomboBox.SelectedIndex == 7)
            {
                this.Form_Clear();
                this.groups_Invisible();
                this.OrganicPorosityGB.Location = new Point(80, 136);
                this.OrganicPorosityGB.Visible = true;
            }
            else if (ChooseFunctionalitycomboBox.SelectedIndex == 8)
            {
                this.Form_Clear();
                this.groups_Invisible();
                this.PoissonRatioGB.Location = new Point(80, 136);
                this.PoissonRatioGB.Visible = true;
            }
            else if (ChooseFunctionalitycomboBox.SelectedIndex == 9)
            {
                this.Form_Clear();
                this.groups_Invisible();
                this.PRYMAM_GB.Location = new Point(80, 136);
                this.PRYMAM_GB.Visible = true;
            }
            else if (ChooseFunctionalitycomboBox.SelectedIndex == 10)
            {
                this.Form_Clear();
                this.groups_Invisible();
                this.TotalOrganicPorosityGB.Location = new Point(80, 126);
                this.TotalOrganicPorosityGB.Visible = true;
            }
            else if (ChooseFunctionalitycomboBox.SelectedIndex == 11)
            {
                this.Form_Clear();
                this.groups_Invisible();
                this.VolumeOfShaleGB.Location = new Point(80, 136);
                this.VolumeOfShaleGB.Visible = true;
            }
            else if (ChooseFunctionalitycomboBox.SelectedIndex == 12)
            {
                this.Form_Clear();
                this.groups_Invisible();
                this.YoungModulusGB.Location = new Point(80, 136);
                this.YoungModulusGB.Visible = true;
            }
        }

        private void BlankTigerpictureBox_Click(object sender, EventArgs e)
        {

        }

        private void BlankGB_Enter(object sender, EventArgs e)
        {

        }

        private void BlankLogopictureBox_Click(object sender, EventArgs e)
        {

        }

        private void FracScopeUI_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Form_Clear();
            this.groups_Invisible();
            this.ClayPorosityGB.Location = new Point(80, 136);
            this.ClayPorosityGB.Visible = true;
        }
        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        private void tabPageGPOutput_Click(object sender, EventArgs e)
        {

        }
        #endregion



    }
}
