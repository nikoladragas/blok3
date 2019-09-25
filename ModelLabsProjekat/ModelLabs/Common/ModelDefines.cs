using System;
using System.Collections.Generic;
using System.Text;

namespace FTN.Common
{
	
	public enum DMSType : short
	{		
		MASK_TYPE							= unchecked((short)0xFFFF),

		SERIESCOMPENSATOR							= 0x0001,
		CONNECTIVITYNODE							= 0x0002,
		TERMINAL    								= 0x0003,
		DCLINESEGMENT        						= 0x0004,
		ACLINESEGMENT   							= 0x0005,
        PERLENGTHSEQIMP                             = 0x0006,
    }

    [Flags]
	public enum ModelCode : long
	{
		IDOBJ								= 0x1000000000000000,
		IDOBJ_GID							= 0x1000000000000104,
		
		PSR									= 0x1100000000000000,
            
		EQUIPMENT							= 0x1110000000000000,
		
		CONDEQ								= 0x1111000000000000,
        CONDEQ_TERMINALS                    = 0x1111000000000119,

        SERIESCOMP                          = 0x1111100000010000,
        SERIESCOMP_R                        = 0x1111100000010105,
        SERIESCOMP_R0                       = 0x1111100000010205,
        SERIESCOMP_X                        = 0x1111100000010305,
        SERIESCOMP_X0                       = 0x1111100000010405,

        CONDUCTOR                           = 0x1111200000000000,
        CONDUCTOR_LENGTH                    = 0x1111200000000105,

        DCLINESEGMENT                       = 0x1111210000040000,

        ACLINESEGMENT                       = 0x1111220000050000,
        ACLINESEGMENT_B0CH                  = 0x1111220000050105,
        ACLINESEGMENT_BCH                   = 0x1111220000050205,
        ACLINESEGMENT_G0CH                  = 0x1111220000050305,
        ACLINESEGMENT_GCH                   = 0x1111220000050405,
        ACLINESEGMENT_R                     = 0x1111220000050505,
        ACLINESEGMENT_R0                    = 0x1111220000050605,
        ACLINESEGMENT_X                     = 0x1111220000050705,
        ACLINESEGMENT_X0                    = 0x1111220000050805,
        ACLINESEGMENT_PERLENGTHIMP          = 0x1111220000050909,

        CONNECTIVITYNODE                    = 0x1200000000020000,
        CONNECTIVITYNODE_DESCRIPTION        = 0x1200000000020107,
        CONNECTIVITYNODE_TERMINALS          = 0x1200000000020219,
        
        TERMINAL                            = 0x1400000000030000,
        TERMINAL_CONDEQ                     = 0x1400000000030109,
        TERMINAL_CONNECTIVITYNODE           = 0x1400000000030209,

        PERLENGTHIMP                        = 0x1300000000000000,
        PERLENGTHIMP_ACLINESEGMENTS         = 0x1300000000000119,

        PERLENGTHSEQIMP                     = 0x1310000000060000,
        PERLENGTHSEQIMP_B0CH                = 0x1310000000060105,
        PERLENGTHSEQIMP_BCH                 = 0x1310000000060205,
        PERLENGTHSEQIMP_G0CH                = 0x1310000000060305,
        PERLENGTHSEQIMP_GCH                 = 0x1310000000060405,
        PERLENGTHSEQIMP_R                   = 0x1310000000060505,
        PERLENGTHSEQIMP_R0                  = 0x1310000000060605,
        PERLENGTHSEQIMP_X                   = 0x1310000000060705,
        PERLENGTHSEQIMP_X0                  = 0x1310000000060805,








    }

    [Flags]
	public enum ModelCodeMask : long
	{
		MASK_TYPE			 = 0x00000000ffff0000,
		MASK_ATTRIBUTE_INDEX = 0x000000000000ff00,
		MASK_ATTRIBUTE_TYPE	 = 0x00000000000000ff,

		MASK_INHERITANCE_ONLY = unchecked((long)0xffffffff00000000),
		MASK_FIRSTNBL		  = unchecked((long)0xf000000000000000),
		MASK_DELFROMNBL8	  = unchecked((long)0xfffffff000000000),		
	}																		
}


