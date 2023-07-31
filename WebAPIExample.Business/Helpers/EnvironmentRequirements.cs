using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIExample.Business.Helpers
{
  public static class EnvironmentRequirements
  {
    public static string GetEnvironmentVariable(string name)
    {
      var value = System.Environment.GetEnvironmentVariable(name);
      if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException($"Environment variable {name} is required", nameof(name));
      return value;
    }

    public static string GetEnvironmentVariable(string variableName, string childVariableName)
    {
      var value = System.Environment.GetEnvironmentVariable(variableName);
      if (string.IsNullOrWhiteSpace(value)) throw new System.ArgumentException($"Enviroment variable {variableName} is required", nameof(variableName));
      var variable = value.Split(";").FirstOrDefault(e => e.Contains($"{childVariableName}="));
      if (variable == null) throw new System.ArgumentException($"Enviroment variable {childVariableName} not found", nameof(childVariableName));

      return variable.Split("=")[1];
    }
  }
}