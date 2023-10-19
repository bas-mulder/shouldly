﻿public class ShouldContainKey
{
    [Fact]
    public void ClassScenarioShouldFail()
    {
        Verify.ShouldFail(() =>
                _classDictionary.ShouldContainKey(new(), "Some additional context"),

            errorWithSource:
            @"_classDictionary
    should contain key
Shouldly.Tests.TestHelpers.MyThing (000000)
    but does not

Additional Info:
    Some additional context",

            errorWithoutSource:
            @"[[Shouldly.Tests.TestHelpers.MyThing (000000) => Shouldly.Tests.TestHelpers.MyThing (000000)]]
    should contain key
Shouldly.Tests.TestHelpers.MyThing (000000)
    but does not

Additional Info:
    Some additional context");
    }

    [Fact]
    public void GuidScenarioShouldFail()
    {
        Verify.ShouldFail(() =>
                _guidDictionary.ShouldContainKey(_missingGuid, "Some additional context"),

            errorWithSource:
            @"_guidDictionary
    should contain key
5250646b-4c46-4b0e-86d8-e1421f2a0ea2
    but does not

Additional Info:
    Some additional context",

            errorWithoutSource:
            @"[[468a57a7-ca19-4b76-a1e3-3040719392bc => a9db46cc-9d3c-4595-ae1b-8e33de4cc6e5]]
    should contain key
5250646b-4c46-4b0e-86d8-e1421f2a0ea2
    but does not

Additional Info:
    Some additional context");
    }

    [Fact]
    public void StringScenarioShouldFail()
    {
        Verify.ShouldFail(() =>
                _stringDictionary.ShouldContainKey("bar", "Some additional context"),

            errorWithSource:
            @"_stringDictionary
    should contain key
""bar""
    but does not

Additional Info:
    Some additional context",

            errorWithoutSource:
            @"[[""Foo"" => """"]]
    should contain key
""bar""
    but does not

Additional Info:
    Some additional context");
    }

    [Fact]
    public void ShouldPass()
    {
        _classDictionary.ShouldContainKey(ThingKey);
        _guidDictionary.ShouldContainKey(GuidKey);
        _stringDictionary.ShouldContainKey("Foo");
    }

    private static readonly MyThing ThingKey = new();
    private readonly Dictionary<MyThing, MyThing> _classDictionary = new()
    {
        { ThingKey, new() }
    };

    private readonly Dictionary<Guid, Guid> _guidDictionary = new()
    {
        { GuidKey, new("a9db46cc-9d3c-4595-ae1b-8e33de4cc6e5") }
    };

    private static readonly Guid GuidKey = new("468a57a7-ca19-4b76-a1e3-3040719392bc");
    private readonly Guid _missingGuid = new("5250646b-4c46-4b0e-86d8-e1421f2a0ea2");

    private readonly Dictionary<string, string> _stringDictionary = new()
    {
        { "Foo", "" }
    };
}