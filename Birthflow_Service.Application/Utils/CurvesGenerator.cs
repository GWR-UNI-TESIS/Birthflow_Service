using BirthflowService.Application.Interfaces;
using BirthflowService.Domain.Entities;
using BirthflowService.Domain.Interface;
using BirthflowService.Domain.Models;

namespace BirthflowService.Application.Utils
{
    public class CurvesGenerator : ICurvesGenerator
    {
        private readonly IPartographRepository _partographRepository;
        public CurvesGenerator(IPartographRepository partographRepository) 
        {
            _partographRepository = partographRepository;
        }

        public Curves GenerateCurves(PartographEntity partographEntity)
        {
            if(partographEntity.WorkTime == null || partographEntity.CervicalDilationEntities == null || partographEntity.CervicalDilationEntities.Count == 0 )
            {
                return new Curves();
            }
            
            List<AlertCurve>? alertCurve = null;
            List<AlertCurve>? newAlertCurve = null;


            var fork = partographEntity.CervicalDilationEntities.FirstOrDefault(dropdown => dropdown.RemOrRam == true);

            alertCurve = GenerateAlertCurve(partographEntity.WorkTime, partographEntity.CervicalDilationEntities.ToList());

            if (fork != null)
            {
                newAlertCurve = GenerateNewAlertCurve(partographEntity.WorkTime, partographEntity.CervicalDilationEntities.ToList(), fork);
            }

            return new Curves() { AlertCurve= alertCurve, newAlertCurve = newAlertCurve};
        }
        

        private List<AlertCurve> GenerateNewAlertCurve(string workTime, List<CervicalDilationEntity> cervicalDilations, CervicalDilationEntity fork)
        {

            string newWorkTime = WorkTimeItemsNewAlert(workTime);

            var defaultValue = _partographRepository.GetWorkTimeItems(workTime);
            var newDefaultValue = _partographRepository.GetWorkTimeItems(newWorkTime);
            var now = DateTime.UtcNow;
            var firstItem = cervicalDilations.FirstOrDefault();

            if (firstItem!.Value >= 4.5)
            {
                return NewAlertCurve( fork.Value, new AlertCurve() { CervicalDilation = firstItem.Value, Time = firstItem.Hour}, defaultValue, newDefaultValue);
            }
            else
            {
                if (cervicalDilations.Count >= 2)
                {
                    AlertCurve? data = null;
                    for (int index = 1; index <= cervicalDilations.Count - 1; index++)
                    {
                        if (cervicalDilations[index - 1].Value <= 4.5 && cervicalDilations[index].Value >= 4.5)
                        {
                            double minute1 = cervicalDilations[index - 1].Hour.Minute / 60.0;
                            double minute2 = cervicalDilations[index].Hour.Minute / 60.0;

                            double x1 = cervicalDilations[index - 1].Hour.Hour + minute1;
                            double x2 = cervicalDilations[index].Hour.Hour + minute2;

                            // Punto y del elemento anterior
                            double y1 = cervicalDilations[index - 1].Value;
                            // Punto y del elemento actual
                            double y2 = cervicalDilations[index].Value;

                            double m = (y2 - y1) / (x2 - x1);
                            double b = y1 - (m * x1);

                            double x = (4.5 - b) / m;
                            int hora = (int)Math.Floor(x);
                            int minutos = (int)Math.Round((x - hora) * 60);

                            data = new AlertCurve
                            {
                                Time = new DateTime(now.Year, now.Month, now.Day, hora, minutos, 0),
                                CervicalDilation = 4.5
                            };
                        }
                    }
                    return NewAlertCurve(fork.Value, data!, defaultValue, newDefaultValue);
                }
                else
                {
                    return new List<AlertCurve>();
                }
            }         
        }

        private List<AlertCurve> GenerateAlertCurve(string workTime, List<CervicalDilationEntity> cervicalDilations)
        {
            var defaultValue = _partographRepository.GetWorkTimeItems(workTime);
            var now = DateTime.UtcNow;
            var firstItem = cervicalDilations.FirstOrDefault();

            if (firstItem!.Value >= 4.5)
            {
                return AlertCurve(new AlertCurve() { CervicalDilation = firstItem.Value, Time = firstItem.Hour}, defaultValue);
            }
            else
            {
                if (cervicalDilations.Count >= 2)
                {
                    AlertCurve? data = null;
                    for (int index = 1; index <= cervicalDilations.Count - 1; index++)
                    {
                        if (cervicalDilations[index - 1].Value <= 4.5 && cervicalDilations[index].Value >= 4.5)
                        {
                            double minute1 = cervicalDilations[index - 1].Hour.Minute / 60.0;
                            double minute2 = cervicalDilations[index].Hour.Minute / 60.0;

                            double x1 = cervicalDilations[index - 1].Hour.Hour + minute1;
                            double x2 = cervicalDilations[index].Hour.Hour + minute2;

                            // Punto y del elemento anterior
                            double y1 = cervicalDilations[index - 1].Value;
                            // Punto y del elemento actual
                            double y2 = cervicalDilations[index].Value;

                            double m = (y2 - y1) / (x2 - x1);
                            double b = y1 - (m * x1);

                            double x = (4.5 - b) / m;
                            int hora = (int)Math.Floor(x);
                            int minutos = (int)Math.Round((x - hora) * 60);

                            data = new AlertCurve
                            {
                                Time = new DateTime(now.Year, now.Month, now.Day, hora, minutos, 0),
                                CervicalDilation = 4.5
                            };
                        }
                    }
                    return AlertCurve(data!, defaultValue);
                }
                else
                {
                    return new List<AlertCurve>();
                }
            }         
        }

        private string WorkTimeItemsNewAlert(string workTime)
        {
            if(workTime == "HMI")
            {
                return "HMR";
            }
            else if (workTime == "HNI")
            {
                return "HNR";
            }
            else
            {
                return workTime;
            }
        }

        private List<AlertCurve> AlertCurve(AlertCurve firstCervicalDilation, List<WorkTimeItemEntity> defaultValues)
        {
            var generateList = new List<AlertCurve>
            {
                firstCervicalDilation
            };

            for (int index = 0; index <= defaultValues.Count - 1; index++)
            {
                if (defaultValues[index].CervicalDilation > firstCervicalDilation.CervicalDilation)
                {
                    // Añade el punto a la nueva lista utilizando la lista de valores predeterminados
                    AlertCurve generatePoint = new AlertCurve
                    {
                        Time = generateList.Last().Time.Add(defaultValues[index].Time),
                        CervicalDilation = defaultValues[index].CervicalDilation
                    };

                    generateList.Add(generatePoint);
                }
            }
            return generateList;
        }


        private List<AlertCurve> NewAlertCurve(double fork, AlertCurve firstCervicalDilation, List<WorkTimeItemEntity> defaultValues, List<WorkTimeItemEntity> ForkValues)
        {
            var generateList = new List<AlertCurve>
            {
                firstCervicalDilation
            };

            for (int index = 0; index <= defaultValues.Count - 1; index++)
            {
                if (defaultValues[index].CervicalDilation > firstCervicalDilation.CervicalDilation)
                {
                    // Si el valor de Y del punto actual es mayor al punto donde el ramorem es activo, se cambia la lista donde están los puntos rotos
                    if (defaultValues[index].CervicalDilation > fork)
                    {
                        AlertCurve generatePoint = new AlertCurve
                        {
                            Time = generateList.Last().Time.Add(ForkValues[index].Time),
                            CervicalDilation = ForkValues[index].CervicalDilation
                        };

                        generateList.Add(generatePoint);
                    }
                    else
                    {
                        AlertCurve generatePoint = new AlertCurve
                        {
                            Time = generateList.Last().Time.Add(defaultValues[index].Time),
                            CervicalDilation = defaultValues[index].CervicalDilation
                        };

                        generateList.Add(generatePoint);
                    }
                }
            }

            return generateList;
        }
    }
}
