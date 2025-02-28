﻿using System.Collections.Generic;
using Bit.BlazorUI.Playground.Web.Models;
using Bit.BlazorUI.Playground.Web.Pages.Components.ComponentDemoBase;

namespace Bit.BlazorUI.Playground.Web.Pages.Components.List;

public partial class BitBasicListDemo
{
    private List<Person> People1 = new();
    private List<Person> People2 = new();

    private readonly List<ComponentParameter> componentParameters = new()
    {
        new ComponentParameter()
        {
            Name = "Items",
            Type = "ICollection<TItem>",
            DefaultValue = "",
            Description = "List of items want to render.",
        },
        new ComponentParameter()
        {
            Name = "ItemSize",
            Type = "int",
            DefaultValue = "50",
            Description = "The height of each item in pixels.",
        },
        new ComponentParameter()
        {
            Name = "OverscanCount",
            Type = "int",
            DefaultValue = "3",
            Description = "determines how many additional items are rendered before and after the visible region.",
        },
        new ComponentParameter()
        {
            Name = "Role",
            Type = "string",
            DefaultValue = "list",
            Description = "Role of the BasicList.",
        },
        new ComponentParameter()
        {
            Name = "RowTemplate",
            Type = "RenderFragment<TItem>",
            DefaultValue = "",
            Description = "content of each item. it should determin with context attribute.",
        },
        new ComponentParameter()
        {
            Name = "Virtualize",
            Type = "bool",
            DefaultValue = "false",
            Description = "virtualize rendering the list, UI rendering to just the parts that are currently visible.",
        },
        new ComponentParameter()
        {
            Name = "Visibility",
            Type = "BitComponentVisibility",
            LinkType = LinkType.Link,
            Href = "#component-visibility-enum",
            DefaultValue = "BitComponentVisibility.Visible",
            Description = "Whether the component is Visible,Hidden,Collapsed.",
        },
    };

    private readonly List<EnumParameter> enumParameters = new()
    {
        new EnumParameter()
        {
            Id = "component-visibility-enum",
            Title = "BitComponentVisibility Enum",
            Description = "",
            EnumList = new List<EnumItem>()
            {
                new EnumItem()
                {
                    Name= "Visible",
                    Description="Show content of the component.",
                    Value="0",
                },
                new EnumItem()
                {
                    Name= "Hidden",
                    Description="Hide content of the component,though the space it takes on the page remains.",
                    Value="1",
                },
                new EnumItem()
                {
                    Name= "Collapsed",
                    Description="Hide content of the component,though the space it takes on the page gone.",
                    Value="2",
                }
            }
        }
    };

    protected override void OnInitialized()
    {
        People1 = GetPeople(8000);
        People2 = GetPeople(100);

        base.OnInitialized();
    }

    private List<Person> GetPeople(int itemCount)
    {
        List<Person> people = new();

        for (int i = 0; i < itemCount; i++)
        {
            people.Add(new Person
            {
                Id = i + 1,
                FirstName = $"Person {i + 1}",
                LastName = $"Person Family {i + 1}",
                Job = $"Programmer {i + 1}"
            });
        }

        return people;
    }

    private readonly string example1HTMLCode = @"
<BitBasicList Items=""People"" Virtualize=""true"" Style=""border: 1px #a19f9d solid; border-radius: 3px; "">
    <RowTemplate Context=""person"">
        <div style=""border-bottom: 1px #8a8886 solid; padding: 5px 20px; margin: 10px;"">
            <img src=""https://picsum.photos/100/100?random=@(person.Id)"">
            <div style=""margin-left:3%; display: inline-block;"">
                <p>Id: <strong>@person.Id</strong></p>
                <p>Full Name: <strong>@person.FirstName @person.LastName</strong></p>
                <p>Job: <strong>@person.Job</strong></p>
            </div>
        </div>
    </RowTemplate>
</BitBasicList>";
    private readonly string example1CSharpCode = @"
List<Person> People = new();
protected override void OnInitialized()
{
    People = GetPeople(100);    
    base.OnInitialized();
}

private List<Person> GetPeople(int itemCount)
{
    List<Person> people = new();

    for (int i = 0; i < itemCount; i++)
    {
        people.Add(new Person
        {
            Id = i + 1,
            FirstName = $""Person {i + 1}"",
            LastName = $""Person Family {i + 1}"",
            Job = $""Programmer {i + 1}""
        });
    }

    return people;
}

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Job { get; set; }
}";

    private readonly string example2HTMLCode = @"
<BitBasicList Items=""People"" Virtualize=""false"" Style=""border: 1px #a19f9d solid; border-radius: 3px; "">
    <RowTemplate Context=""person"">
        <div style=""border-bottom: 1px #8a8886 solid; padding: 5px 20px; margin: 10px;"">
            <p>Id: <strong>@person.Id</strong></p>
            <p>Full Name: <strong>@person.FirstName @person.LastName</strong></p>
            <p>Job: <strong>@person.Job</strong></p>
        </div>
    </RowTemplate>
</BitBasicList>";
    private readonly string exampl2CSharpCode = @"
List<Person> People = new();
protected override void OnInitialized()
{
    People = GetPeople(100);    
    base.OnInitialized();
}

private List<Person> GetPeople(int itemCount)
{
    List<Person> people = new();

    for (int i = 0; i < itemCount; i++)
    {
        people.Add(new Person
        {
            Id = i + 1,
            FirstName = $""Person {i + 1}"",
            LastName = $""Person Family {i + 1}"",
            Job = $""Programmer {i + 1}""
        });
    }

    return people;
}

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Job { get; set; }
}";

    private readonly string example3CSharpCode = @"
List<Person> People = new();
protected override void OnInitialized()
{
    People = GetPeople(8000);    
    base.OnInitialized();
}

public List<Person> GetPeople(int itemCount)
{
    List<Person> people = new();

    for (int i = 0; i < itemCount; i++)
    {
        people.Add(new Person
        {
            Id = i + 1,
            FirstName = $""Person {i + 1}"",
            LastName = $""Person Family {i + 1}"",
            Job = $""Programmer {i + 1}""
        });
    }

    return people;
}

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Job { get; set; }
}";
    private readonly string example3HTMLCode = @"
<BitBasicList Items=""People"" Virtualize=""true"" Role=""list"" Style=""border: 1px #a19f9d solid; border-radius: 3px;"">
    <RowTemplate Context=""person"">
        <div class=""lst3-list-item"">
            <span>Id: <strong>@person.Id</strong></span>
            <span>Full Name: <strong>@person.FirstName</strong></span>
            <span>Job: <strong>@person.Job</strong></span>
        </div>
    </RowTemplate>
</BitBasicList>
<style>
    .lst3-list-item {
    padding: 16px 20px;
    background-color: #f2f2f2;
    margin: 10px 10px;
    width: 20%;
    height: 143px;
    display: inline-grid;
    justify-content: center;
    align-items: center;
    }
</style>
";

    private readonly string example4HTMLCode = @"<BitBasicList Items=""People"" Virtualize=""true"" OverscanCount=""5"" ItemSize=""300"" Style=""border: 1px #a19f9d solid; border-radius: 3px; "">
    <RowTemplate Context=""person"">
        <div style=""border-bottom: 1px #8a8886 solid; padding: 5px 20px; margin: 10px;"">
            <p>Id: <strong>@person.Id</strong></p>
            <p>Full Name: <strong>@person.FirstName @person.LastName</strong></p>
            <p>Job: <strong>@person.Job</strong></p>
        </div>
    </RowTemplate>
</BitBasicList>";
    private readonly string example4CSharpCode = @"
List<Person> People = new();
protected override void OnInitialized()
{
    People = GetPeople(8000);    
    base.OnInitialized();
}

public List<Person> GetPeople(int itemCount)
{
    List<Person> people = new();

    for (int i = 0; i < itemCount; i++)
    {
        people.Add(new Person
        {
            Id = i + 1,
            FirstName = $""Person {i + 1}"",
            LastName = $""Person Family {i + 1}"",
            Job = $""Programmer {i + 1}""
        });
    }

    return people;
}

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Job { get; set; }
}";
}
