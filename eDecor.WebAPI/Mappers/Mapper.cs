using AutoMapper;
using eDecor.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDecor.WebAPI.Mappers
{
    public class Mapper: Profile
    {
        public Mapper() {
            //Artikli
            CreateMap<Database.Artikli, Model.Artikli>();//.AddTransform - ako postoje polja koja se trebaju mapirati a imaju razlicita imena
            CreateMap<ArtikliUpsertRequest, Database.Artikli>();//.ReverseMap();//radi u oba smjera
            //Drzave
            CreateMap<Database.Drzave, Model.Drzave>();
            CreateMap<DrzaveUpsertRequest, Database.Drzave>();
            //Gradovi
            CreateMap<Database.Gradovi, Model.Gradovi>();
            CreateMap<GradoviUpsertRequest, Database.Gradovi>();
            //Kategorije
            CreateMap<Database.Kategorije, Model.Kategorije>();
            CreateMap<KategorijeUpsertRequest, Database.Kategorije>();
            //Klijenti
            CreateMap<Database.Klijenti, Model.Klijenti>();
            CreateMap<KlijentiUpsertRequest, Database.Klijenti>();
            //Korisnici
            CreateMap<Database.Korisnici, Model.Korisnici>();
            CreateMap<KorisniciUpsertRequest, Database.Korisnici>();
            //KorisniciUloge
            CreateMap<Database.KorisniciUloge, Model.KorisniciUloge>().ReverseMap();
            //Notifikacije
            CreateMap<Database.Notifikacije, Model.Notifikacije>();
            CreateMap<NotifikacijeUpsertRequest, Database.Notifikacije>();
            //Ocjene
            CreateMap<Database.Ocjene, Model.Ocjene>();
            CreateMap<OcjeneUpsertRequest, Database.Ocjene>();
            //Podkategorije
            CreateMap<Database.Podkategorije, Model.Podkategorije>();
            CreateMap<PodkategorijeUpsertRequest, Database.Podkategorije>();
            //Popusti
            CreateMap<Database.Popusti, Model.Popusti>();
            CreateMap<PopustiUpsertRequest, Database.Popusti>();
            //Pretplate
            CreateMap<Database.Pretplate, Model.Pretplate>();
            CreateMap<PretplateUpsertRequest, Database.Pretplate>();
            //Rezervacije
            CreateMap<Database.Rezervacije, Model.Rezervacije>();
            CreateMap<RezervacijeUpsertRequest, Database.Rezervacije>();
            //RezervacijeArtikli
            CreateMap<Database.RezervacijeArtikli, Model.RezervacijeArtikli>();
            //Uloge
            CreateMap<Database.Uloge, Model.Uloge>();
            //Login
            CreateMap<Database.Klijenti, Model.Korisnici>().ReverseMap();
        }
    }
}
