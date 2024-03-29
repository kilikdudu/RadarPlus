﻿using ClubManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagement.IBLL
{
    public interface IAudio
    {
        AudioCanalEnum Canal { get; set; }
        float Volume { get; set; }
        void play(string[] arquivos);
        void play(string arquivo);
    }
}
