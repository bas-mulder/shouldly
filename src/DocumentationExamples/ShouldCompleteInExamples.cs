﻿using Shouldly;
using Xunit;
using Xunit.Abstractions;

public class ShouldCompleteInExamples
{
    private readonly ITestOutputHelper _testOutputHelper;

    public ShouldCompleteInExamples(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact(Skip = "Flaky test")]
    public void ShouldCompleteIn()
    {
        DocExampleWriter.Document(
            () =>
            {
                Should.CompleteIn(
                    action: () => { Thread.Sleep(TimeSpan.FromSeconds(2)); },
                    timeout: TimeSpan.FromSeconds(1),
                    customMessage: "Some additional context");
            },
            _testOutputHelper);
    }
}