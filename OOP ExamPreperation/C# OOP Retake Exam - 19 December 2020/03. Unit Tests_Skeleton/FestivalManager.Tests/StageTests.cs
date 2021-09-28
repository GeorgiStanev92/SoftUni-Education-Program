// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class StageTests
    {
		[Test]
		public void ValidateNullValueShouldTrowException()
		{
			Stage stage = new Stage();

			Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null));
			Assert.Throws<ArgumentNullException>(() => stage.AddSong(null));

		}
		[Test]
		public void AddPerformerMethodThrowExceptionWhenAgeIsBelow18()
		{
			Stage stage = new Stage();
			Performer performer = new Performer("Gosho", "Ivanov", 10);
			Assert.Throws<ArgumentException>(() => stage.AddPerformer(performer));

		}
		[Test]
		public void AddPerformerMethodSholudWork()
		{
			Stage stage = new Stage();
			Performer performer = new Performer("Gosho", "Ivanov", 18);
			stage.AddPerformer(performer);
			var actualResult = stage.Performers.Count;
			var expectedResult = 1;
			Assert.AreEqual(expectedResult, actualResult);

		}
		[Test]
		public void AddSongMethodThrowExceptionWhenSongDurationBelow1Minut()
		{
			Stage stage = new Stage();

			Song song = new Song("Where are you", TimeSpan.FromMinutes(0.9));
			Assert.Throws<ArgumentException>(() => stage.AddSong(song));

		}
		[Test]
		public void AddSongMethodShouldWork()
		{
			Stage stage = new Stage();

			Song song = new Song("Where", TimeSpan.FromMinutes(2));
			Performer performer01 = new Performer("Pesho", "Ivanov", 21);

			stage.AddSong(song);
			stage.AddPerformer(performer01);
			var actualResult = stage.AddSongToPerformer("Where", "Pesho Ivanov");
			var expectedResult = "Where (02:00) will be performed by Pesho Ivanov";
			Assert.AreEqual(expectedResult, actualResult);

		}
		[Test]
		public void AddSongToPerformerMethodThrowExceptionWhenEntriDataIsNull()
		{
			Stage stage = new Stage();

			Song song = new Song("Where are you", TimeSpan.FromMinutes(3));
			Performer performer = new Performer("Gosho", "Ivanov", 21);

			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null, "Gosho"));
			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer("Where are you", null));
			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null, null));

		}
		[Test]
		public void AddSongToPerformanceMethodShouldWork()
		{
			Stage stage = new Stage();

			Song song = new Song("Where", TimeSpan.FromMinutes(3));
			Performer performer = new Performer("Gosho", "Ivanov", 30);
			stage.AddPerformer(performer);
			stage.AddSong(song);
			var actualResult = stage.AddSongToPerformer("Where", "Gosho Ivanov");
			var expectedResult = "Where (03:00) will be performed by Gosho Ivanov";
			Assert.AreEqual(expectedResult, actualResult);
		}
		[Test]
		public void PlayMethodShouldWork()
		{

			Stage stage = new Stage();

			Song song01 = new Song("Where", TimeSpan.FromMinutes(5));
			Song song02 = new Song("Are", TimeSpan.FromMinutes(10));
			Song song03 = new Song("You", TimeSpan.FromMinutes(4.5));
			Song song04 = new Song("Now", TimeSpan.FromMinutes(10.5));
			Performer performer01 = new Performer("Pesho", "Ivanov", 21);
			Performer performer02 = new Performer("Gosho", "Toshev", 21);

			stage.AddSong(song01);
			stage.AddSong(song02);
			stage.AddSong(song03);
			stage.AddSong(song04);
			stage.AddPerformer(performer01);
			stage.AddPerformer(performer02);
			stage.AddSongToPerformer("Where", "Pesho Ivanov");
			stage.AddSongToPerformer("Are", "Pesho Ivanov");
			stage.AddSongToPerformer("You", "Gosho Toshev");
			var actualResult = stage.Play();
			var expectedResult = "2 performers played 3 songs";
			Assert.AreEqual(expectedResult, actualResult);

		}

	}
}