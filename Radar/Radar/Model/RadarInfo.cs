﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Model
{
    [Table("radar")]
    public class RadarInfo
    {
        private int _Id;
        private double _Latitude;
        private double _Longitude;
        private double _LatitudeCos;
        private double _LongitudeCos;
        private double _LatitudeSin;
        private double _LongitudeSin;
        private int _Tipo;
        private int _Velocidade;
        private int _Direcao;

        [PrimaryKey, AutoIncrement, Obsolete("Usando em Id")]
        public int id_radar {
            get {
                return _Id;
            }
            set {
                _Id = value;
            }
        }

        [Obsolete("Usando Latitude")]
        public double lat {
            get {
                return _Latitude;
            }
            set {
                _Latitude = value;
            }
        }

        [Obsolete("Usando Longitude")]
        public double lon {
            get {
                return _Longitude;
            }
            set {
                _Longitude = value;
            }
        }

        [Obsolete("Usando LatitudeCos")]
        public double latcos {
            get {
                return _LatitudeCos;
            }
            set {
                _LatitudeCos = value;
            }
        }

        [Obsolete("Usando LatitudeSin")]
        public double latsin {
            get {
                return _LatitudeSin;
            }
            set {
                _LatitudeSin = value;
            }
        }

        [Obsolete("Usando LongitudeCos")]
        public double loncos {
            get {
                return _LongitudeCos;
            }
            set {
                _LongitudeCos = value;
            }
        }

        [Obsolete("Usando LongitudeSin")]
        public double lonsin {
            get {
                return _LongitudeSin;
            }
            set {
                _LongitudeSin = value;
            }
        }

        [Obsolete("Usando Tipo")]
        public int type {
            get {
                return _Tipo;
            }
            set {
                _Tipo = value;
            }
        }

        [Obsolete("Usando Velocidade")]
        public int speed {
            get {
                //return _Velocidade;
                return 40;
            }
            set {
                _Velocidade = value;
            }
        }

        [Obsolete("Não está usando em nenhum lugar.")]
        public int dirtype { get; set; }

        [Obsolete("Usando a Direcao.")]
        public int direction {
            get {
                return _Direcao;
            }
            set {
                _Direcao = value;
            }
        }

        [Obsolete("Não está usando em nenhum lugar.")]
        public int usuario { get; set; }

        [Ignore]
        public int Id {
            get {
                return _Id;
            }
            set {
                _Id = value;
            }
        }

        [Ignore]
        public double Latitude {
            get {
                return _Latitude;
            }
            set {
                _Latitude = value;
            }
        }

        [Ignore]
        public double Longitude {
            get {
                return _Longitude;
            }
            set {
                _Longitude = value;
            }
        }

        [Ignore]
        public double LatitudeCos {
            get {
                return _LatitudeCos;
            }
            set {
                _LatitudeCos = value;
            }
        }

        [Ignore]
        public double LongitudeCos {
            get {
                return _LongitudeCos;
            }
            set {
                _LongitudeCos = value;
            }
        }

        [Ignore]
        public double LatitudeSin {
            get {
                return _LatitudeSin;
            }
            set {
                _LatitudeSin = value;
            }
        }

        [Ignore]
        public double LongitudeSin {
            get {
                return _LongitudeSin;
            }
            set {
                _LongitudeSin = value;
            }
        }

        [Ignore]
        public int Tipo {
            get {
                return _Tipo;
            }
            set {
                _Tipo = value;
            }
        }

        [Ignore]
        public int Velocidade {
            get {
                //return _Velocidade;
                return 40;
            }
            set {
                _Velocidade = value;
            }
        }

        [Ignore]
        public string VelocidadeStr
        {
            get {
                return Velocidade.ToString() + "km/h";
            }
        }

        [Ignore]
        public int Direcao {
            get {
                return _Direcao;
            }
            set {
                _Direcao = value;
            }
        }

        [Ignore]
        public bool Usuario {
            get {
                return (usuario == 1);
            }
            set {
                usuario = (value) ? 1 : 0;
            }
        }
    }

}
