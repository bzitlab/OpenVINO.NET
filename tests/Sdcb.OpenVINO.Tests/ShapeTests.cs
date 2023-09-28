﻿namespace Sdcb.OpenVINO.Tests;

public class ShapeTests
{
    [Fact]
    public void CanCreateFromArray()
    {
        using NativeShape shape = new(new long[] { 1, 2, 3, 4 });
        Assert.Equal(new long[] { 1, 2, 3, 4 }, shape.ToArray());
    }

    [Fact]
    public void CanCreateFromD4()
    {
        using NativeShape shape = new(4, 3, 2, 1);
        Assert.Equal(new long[] { 4, 3, 2, 1 }, shape.ToArray());
    }

    [Fact]
    public void CanCreateFromD2()
    {
        using NativeShape shape = new(4, 3);
        Assert.Equal(4, shape[0]);
        Assert.Equal(3, shape[1]);
    }

    [Fact]
    public void ToStringTest()
    {
        using NativeShape shape = new(4, 3);
        Assert.Equal("{4,3}", shape.ToString());
    }

    [Fact]
    public void CanRevealDisposed()
    {
        using NativeShape shape = new(4, 3, 2, 1);
        Assert.False(shape.Disposed);
        shape.Dispose();
        Assert.True(shape.Disposed);
    }
}
