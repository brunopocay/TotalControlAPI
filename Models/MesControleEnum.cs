﻿using System.Text.Json.Serialization;

namespace TotalControlAPI.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MesControleEnum
    {
        Janeiro = 01,
        Fevereiro = 02,
        Março = 03,
        Abril = 04,
        Maio = 05,
        Junho = 06,
        Julho = 07,
        Agosto = 08,
        Setembro = 09,
        Outubro = 10,
        Novembro = 11,
        Dezembro = 12
    }
}
