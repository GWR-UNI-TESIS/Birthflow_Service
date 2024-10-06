using BirthflowService.Domain.Entities;
using BirthflowService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowService.Application.Interfaces
{
    public interface ICurvesGenerator
    {
        public Curves GenerateCurves(PartographEntity partographEntity);
    }
}
