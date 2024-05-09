using Xunit;
using Moq;
using System.Collections.Generic;
using CineQuebec.Windows.Services.Interfaces;
using CineQuebec.Windows.Domain;

namespace CineQuebec.Tests
{
    public class ServiceFilmNotesTests
    {
        private Mock<IServiceFilmNotes> _serviceFilmNotesMock;
        private Film _film;
        private Abonne _abonne;
        private FilmNote _filmNote;

        public ServiceFilmNotesTests()
        {
            _serviceFilmNotesMock = new Mock<IServiceFilmNotes>();
            _film = new Film();
            _abonne = new Abonne();
            _filmNote = new FilmNote();
        }

        [Fact]
        public void LoadFilmNotes_ReturnsReadOnlyCollectionOfFilmNotes()
        {
            _serviceFilmNotesMock.Setup(s => s.LoadFilmNotes()).Returns(new List<FilmNote> { _filmNote }.AsReadOnly());

            var result = _serviceFilmNotesMock.Object.LoadFilmNotes();

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(_filmNote, result[0]);
        }

        [Fact]
        public void AddFilmNote_ReturnsNewFilmNote()
        {
            _serviceFilmNotesMock.Setup(s => s.AddFilmNote(_film, It.IsAny<byte>(), _abonne)).Returns(_filmNote);

            var result = _serviceFilmNotesMock.Object.AddFilmNote(_film, 5, _abonne);

            Assert.Equal(_filmNote, result);
        }

        [Fact]
        public void ObtenirFilmNoteParAbonneEtFilm_ReturnsFilmNote()
        {
            _serviceFilmNotesMock.Setup(s => s.ObtenirFilmNoteParAbonneEtFilm(_abonne, _film)).Returns(_filmNote);

            var result = _serviceFilmNotesMock.Object.ObtenirFilmNoteParAbonneEtFilm(_abonne, _film);

            Assert.Equal(_filmNote, result);
        }

        [Fact]
        public void ObtenirFilmNoteParAbonneEtFilm_ReturnsNull_WhenNoFilmNoteExists()
        {
            _serviceFilmNotesMock.Setup(s => s.ObtenirFilmNoteParAbonneEtFilm(_abonne, _film)).Returns((FilmNote)null);

            var result = _serviceFilmNotesMock.Object.ObtenirFilmNoteParAbonneEtFilm(_abonne, _film);

            Assert.Null(result);
        }
    }
}