//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HeuristicAlghorithmsComparer.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Result
    {
        public int Id { get; set; }
        public int AlghoritmId { get; set; }
        public int InputParametersId { get; set; }
        public int ResultDetailsId { get; set; }
    
        public virtual Alghoritm Alghoritm { get; set; }
        public virtual InputParameter InputParameter { get; set; }
        public virtual ResultDetail ResultDetail { get; set; }
    }
}
