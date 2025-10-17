namespace OldPhonePadChallenge.Tests;
using Xunit;
public class OldPhonePadTests
{
    [Fact]
    public void OldPhonePad_Example1_ReturnsCorrectOutput()
    {
        // Arrange
        string input = "33#";
        string expected = "E";

        // Act
        string actual = OldPhonePadSolver.OldPhonePad(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void OldPhonePad_Example2_ReturnsCorrectOutput()
    {
        string input = "227*#";
        string expected = "B";
        string actual = OldPhonePadSolver.OldPhonePad(input);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void OldPhonePad_Example3_ReturnsCorrectOutput()
    {
        string input = "4433555 555666#";
        string expected = "HELLO";
        string actual = OldPhonePadSolver.OldPhonePad(input);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void OldPhonePad_Example4_ReturnsCorrectOutput()
    {
        string input = "8 88777444666*664#";
        string expected = "TURING";
        string actual = OldPhonePadSolver.OldPhonePad(input);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void OldPhonePad_EmptyInput_ReturnsEmptyString()
    {
        string input = "#";
        string expected = "";
        string actual = OldPhonePadSolver.OldPhonePad(input);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void OldPhonePad_BackspaceAtStart_ReturnsEmptyString()
    {
        string input = "*#";
        string expected = "";
        string actual = OldPhonePadSolver.OldPhonePad(input);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void OldPhonePad_MultiplePauses_WorksCorrectly()
    {
        string input = "222 2 22#";
        string expected = "CAB";
        string actual = OldPhonePadSolver.OldPhonePad(input);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void OldPhonePad_KyawSwarHein_ReturnsCorrectOutput()
    {
        string input = "55 999 2 9 0 7777 9 2 777 0 44 33 444 66#";
        string expected = "KYAW SWAR HEIN";
        string actual = OldPhonePadSolver.OldPhonePad(input);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void OldPhonePad_IronSoftware_ReturnsCorrectOutput()
    {
        string input = "444 777 666 66 0 7777 666 333 8 9 2 777 33#";
        string expected = "IRON SOFTWARE";
        string actual = OldPhonePadSolver.OldPhonePad(input);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void OldPhonePad_KSH_And_IronSoftware_ReturnsCorrectOutput()
    {
        string input = "55 999 2 9 0 7777 9 2 777 0 44 33 444 66 0 1 0 444 777 666 66 0 7777 666 333 8 9 2 777 33#";
        string expected = "KYAW SWAR HEIN & IRON SOFTWARE";
        string actual = OldPhonePadSolver.OldPhonePad(input);
        Assert.Equal(expected, actual);
    }
}

