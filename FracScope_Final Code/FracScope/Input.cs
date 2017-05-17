using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Slb.Ocean.Core;
using Slb.Ocean.Petrel;
using Slb.Ocean.Petrel.UI;
using Slb.Ocean.Petrel.Workflow;
using Slb.Ocean.Petrel.DomainObject;
using Slb.Ocean.Petrel.DomainObject.Well;

namespace FracScope
{
    public class Input
    {
        private Borehole bh;
        private WellLog wl1;
        private WellLog wl2;
        private WellLog wl3;
        private WellLog wl4;
        private WellLog wl5;
        private WellLog wl6;

        private WellLogVersion wlv1;
        private WellLogVersion wlv2;
        private WellLogVersion wlv3;
        private WellLogVersion wlv4;
        private WellLogVersion wlv5;
        private WellLogVersion wlv6;



        private double rtop;
        private double rbottom;
        private Boolean rtopgiven;
        private Boolean rbottomgiven;
        private double userdepth;
        private float densitymatrix;
        private float densityoffluid;

        private double startdepthofnonkerogenshale;
        private double enddepthofnonkerogenshale;
        private float assumedmatrixdensity;
        private float assumedkerogendensity;
        private float densityofbrine;


        private float graindensity;

        private float constant;


        private float constant1;
        private Boolean constant1_given;
        private float constant2;
        private Boolean constant2_given;


        private float biot_constant;
        private Boolean biot_constant_given;
        private float pore_elastic_constant;
        private Boolean pore_elastic_constant_given;
        private float min_hor_strain;
        private Boolean min_hor_strain_given;
        private float max_hor_strain;
        private Boolean max_hor_strain_given;

        private Boolean ismultiplewelllog;

        private double water_depth;
        private Boolean water_depth_given;

        private String output_file_name;
        private List<String> output_file_name_list;




        public Input()
        {
            rtopgiven = true;
            rbottomgiven = true;
            biot_constant_given = true;
            pore_elastic_constant_given = true;
            min_hor_strain_given = true;
            max_hor_strain_given = true;
            ismultiplewelllog = false;

            this.OutputFileNameList = new List<string>();


        }
        public Borehole Borehole
        {
            internal get { return this.bh; }
            set { this.bh = value; }
        }

        public WellLog WellLog1
        {
            internal get { return this.wl1; }
            set { this.wl1 = value; }
        }
        public WellLog WellLog2
        {
            internal get { return this.wl2; }
            set { this.wl2 = value; }
        }
        public WellLog WellLog3
        {
            internal get { return this.wl3; }
            set { this.wl3 = value; }
        }
        public WellLog WellLog4
        {
            internal get { return this.wl4; }
            set { this.wl4 = value; }
        }
        public WellLog WellLog5
        {
            internal get { return this.wl5; }
            set { this.wl5 = value; }
        }
        public WellLog WellLog6
        {
            internal get { return this.wl6; }
            set { this.wl6 = value; }
        }

        public WellLogVersion Wlv1
        {
            get { return wlv1; }
            set { wlv1 = value; }
        }
        public WellLogVersion Wlv2
        {
            get { return wlv2; }
            set { wlv2 = value; }
        }
        public WellLogVersion Wlv3
        {
            get { return wlv3; }
            set { wlv3 = value; }
        }
        public WellLogVersion Wlv4
        {
            get { return wlv4; }
            set { wlv4 = value; }
        }
        public WellLogVersion Wlv5
        {
            get { return wlv5; }
            set { wlv5 = value; }
        }
        public WellLogVersion Wlv6
        {
            get { return wlv6; }
            set { wlv6 = value; }
        }

        public double ReservoirTop
        {
            internal get { return this.rtop; }
            set { this.rtop = value; }
        }
        public double ReservoirBottom
        {
            internal get { return this.rbottom; }
            set { this.rbottom = value; }
        }

        public Boolean ReservoirTopGiven
        {
            internal get { return this.rtopgiven; }
            set { this.rtopgiven = value; }
        }
        public Boolean ReservoirBottomGiven
        {
            internal get { return this.rbottomgiven; }
            set { this.rbottomgiven = value; }
        }
        public double UserDepth
        {
            internal get { return this.userdepth; }
            set { this.userdepth = value; }
        }
        public float DensityMatrix
        {
            internal get { return this.densitymatrix; }
            set { this.densitymatrix = value; }
        }
        public float DensityOfFluid
        {
            internal get { return this.densityoffluid; }
            set { this.densityoffluid = value; }
        }
        public double StartDepthOfNonkerogenShale
        {
            internal get { return this.startdepthofnonkerogenshale; }
            set { this.startdepthofnonkerogenshale = value; }
        }
        public double EndDepthOfNonKerogenShale
        {
            internal get { return this.enddepthofnonkerogenshale; }
            set { this.enddepthofnonkerogenshale = value; }
        }
        public float AssumedMatrixDensity
        {
            internal get { return this.assumedmatrixdensity; }
            set { this.assumedmatrixdensity = value; }
        }
        public float AssumedKerogenDensity
        {
            internal get { return this.assumedkerogendensity; }
            set { this.assumedkerogendensity = value; }
        }
        public float DensityOfBrine
        {
            internal get { return this.densityofbrine; }
            set { this.densityofbrine = value; }
        }


        public float Constant
        {
            get { return constant; }
            set { constant = value; }
        }

        public float GrainDensity
        {
            get { return graindensity; }
            set { graindensity = value; }
        }

        public float Constant1
        {
            get { return constant1; }
            set { constant1 = value; }
        }
        public Boolean Constant1Given
        {
            get { return constant1_given; }
            set { constant1_given = value; }
        }
        public float Constant2
        {
            get { return constant2; }
            set { constant2 = value; }
        }
        public Boolean Constant2Given
        {
            get { return constant2_given; }
            set { constant2_given = value; }
        }

        public float BiotConstant
        {
            internal get { return this.biot_constant; }
            set { this.biot_constant = value; }
        }
        public Boolean BiotConstantGiven
        {
            internal get { return this.biot_constant_given; }
            set { this.biot_constant_given = value; }
        }
        public float PoreElasticConstant
        {
            internal get { return this.pore_elastic_constant; }
            set { this.pore_elastic_constant = value; }
        }
        public Boolean PoreElasticConstantGiven
        {
            internal get { return this.pore_elastic_constant_given; }
            set { this.pore_elastic_constant_given = value; }
        }
        public float MinHorStrain
        {
            get { return min_hor_strain; }
            set { min_hor_strain = value; }
        }


        public Boolean MinHorStrainGiven
        {
            get { return min_hor_strain_given; }
            set { min_hor_strain_given = value; }
        }


        public float MaxHorStrain
        {
            get { return max_hor_strain; }
            set { max_hor_strain = value; }
        }


        public Boolean MaxHorStrainGiven
        {
            get { return max_hor_strain_given; }
            set { max_hor_strain_given = value; }
        }
        public Boolean IsMultipleWelllog
        {
            get { return ismultiplewelllog; }
            set { ismultiplewelllog = value; }
        }

        public double WaterDepth
        {
            get { return water_depth; }
            set { water_depth = value; }
        }

        public Boolean WaterDepthGiven
        {
            get { return water_depth_given; }
            set { water_depth_given = value; }
        }

        public List<String> OutputFileNameList
        {
            get { return output_file_name_list; }
            set { output_file_name_list = value; }
        }

        public String OutputFileName
        {
            get { return output_file_name; }
            set { output_file_name = value; }
        }
    }
}
