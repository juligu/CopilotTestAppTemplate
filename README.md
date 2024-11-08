# Using GH Copilot

## Generate initial data

Clone the repository using any editor or the command line tool
```
git clone https://github.com/juligu/CopilotTestAppTemplate.git
```
Then, navigate to the solution folder and open it on the code editor
```
cd CopilotTestAppTemplate
code .
```
Locate the following file: **WebAppCustomers\Models\DataContext.cs** and then, ask copilot to explain the file. Read the copilot explanation.
<details>
  <summary>Solution</summary>
  Open the file, right click on the editor and select "Copilot", "Explain". Then select the DataContext object.

  ![Copilot explain menu](/Images/01_01.jpg)
  
  ![DataContext object selected](/Images/01_02.jpg)
  
</details>

Locate the **OnModelCreating** method, then use Copilot to generate 20 Tickets and Save them to the InMemory database
<details>
  <summary>Solution</summary>
  
  Add the following comment
```
  //Generate 20 Tickets data
```
Then copilot will suggest the required code, review the generated code.
```
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    //Generate 20 Tickets data
    for (int i = 1; i <= 20; i++)
    {
        var ticket = new Ticket
        {
            ID = i,
            Title = $"Ticket {i}",
            Description = $"Description for Ticket {i}",
            UserName = $"User {i}",
            Category = new Category
            {
                ID = i,
                Name = $"Category {i}",
                Description = $"Description for Category {i}"
            }
        };
        Tickets.Add(ticket);
    }
}
```
</details>

## Display generated data

Locate the following file **WebAppCustomers\Pages\Tickets\Index.cshtml.cs** and add a new public property, it should be a List of Tickets object
<details>
  <summary>Solution</summary>
  
  ```
  public List<Ticket> Tickets { get; set; }
  ```
</details>


Then, add a contructor that receives the TicketsRepository object as a parameter (Hint: you can ask copilot to add a constructor)
<details>
  <summary>Solution</summary>
  
  ```
  public IndexModel(TicketsRepository _ticketsRepository)
  {
      
  }
  ```
</details>
Add a property to store the TicketsRepository object and assign it in the constructor
<details>
  <summary>Solution</summary>
  
  ```
private readonly TicketsRepository _ticketsRepository;

public IndexModel(TicketsRepository ticketsRepository)
{
    _ticketsRepository = ticketsRepository;
}
  ```
</details>

Implement the OnGet method to assign the result of the TicketsRepository.GetTicketsAsync method to the list of Tickets
details>
  <summary>Solution</summary>
  
  ```
public async Task OnGet()
{
    Tickets = await _ticketsRepository.GetTicketsAsync();
}
```
</details>


Locate the following file **WebAppCustomers\Pages\Tickets\Index.cshtml**, you can create a comment to instruct Copilot to create a table to display the Tickets
```
@* Table to display List<Tickets> *@
```
Complete copilot suggestions, it should look similar to this, double check the code and validate that it makes sense. You can also use the Copilot chat feature.

<details>
  <summary>Solution</summary>
  
  ```
@if (Model.Tickets.Count > 0)
{
    <table class="table">
        <thead>
            <tr>
                <th>
                    @Html.DisplayNameFor(model => model.Tickets[0].ID)
                </th>
                <th>
                    @Html.DisplayNameFor(model => model.Tickets[0].Title)
                </th>
                <th>
                    @Html.DisplayNameFor(model => model.Tickets[0].Description)
                </th>
            </tr>
        </thead>
        <tbody>
            @foreach (var item in Model.Tickets)
            {
                <tr>
                    <td>
                        @Html.DisplayFor(modelItem => item.ID)
                    </td>
                    <td>
                        @Html.DisplayFor(modelItem => item.Title)
                    </td>
                    <td>
                        @Html.DisplayFor(modelItem => item.Description)
                    </td>
                </tr>
            }
        </tbody>
    </table>
}
```
</details>
Execute the application and validate the Tickets Page

![Tickets page](/Images/01_03.jpg)

## Styling

Using Copilot chat ask for a responsive table and a professional style (Hint: you can use the #file instruction to target the Index.cshtml file)
<details>
  <summary>Solution</summary>
  
```
#file:Index.cshtml generate a professional style and a responsive table
```
</details>

## Ticket Details

In the same file, in the generated table, add a link to navigate to the Details page passing the ID of the ticket as a parameter (Hint: you can use Copilot by creating a comment)
<details>
  <summary>Solution</summary>
  
```
@* Link to tickets details *@
<td>
    <a asp-page="Details" asp-route-id="@item.ID">Details</a>
</td>
```
</details>

Locate the **WebAppCustomers\Pages\Tickets\Details.cshtml.cs** file, then create a public Ticket property, a private TicketsRepository property and implement a constructor that receives a TicketsRepository object as a parameter and assign it to the private property
<details>
  <summary>Solution</summary>
  
```
public Ticket TicketItem { get; set; }
private TicketsRepository _repository;

public DetailsModel(TicketsRepository repository)
{
    _repository = repository;
}
```
</details>

Then, implement the OnGet operation, it has to receive an id integer parameter
<details>
  <summary>Solution</summary>
  
```
public async Task OnGet(int id)
{
    TicketItem = await _repository.GetTicketByIdAsync(id);
}
```
</details>

Now, in the **WebAppCustomers\Pages\Tickets\Details.cshtml** file, you can use Copilot to display the information
<details>
  <summary>Solution</summary>
  
```
<h1>Details</h1>

<div>
    <h4>Ticket</h4>
    <hr />
    <dl class="row">
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.TicketItem.ID)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.TicketItem
            .ID)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.TicketItem.Title)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.TicketItem
            .Title)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.TicketItem.Description)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.TicketItem
            .Description)
        </dd>
    </dl>
</div>
```
</details>

Apply some styling using Copilot chat and execute the application, validate the details of the first and the last ticket, is there any issues with the app? is there anything that needs to be investigated?

## Performance troubleshooting

Navigate to the **WebAppCustomers\Data\TicketsRepository.cs** file, locate the **GetTicketByIdAsync** method, highlight the method and right-click on the editor and select Copilot, Explain. Read the copilot output, is there any feedback? any suggestions ? If so, feel free to implement the changes and execute the application and validate it again. You can also use the Copilot chat providing the following input
```
@workspace #selection are there any performance improvements?
```
<details>
  <summary>Solution</summary>
  
```
// Copilot will suggest the following implementation, you can ask the same question multiple times with different implementations and see if there's more room for improvement

public async Task<Ticket> GetTicketByIdAsync(int id)
{
    return await _context.Tickets.FirstOrDefaultAsync(ticket => ticket.ID == id);
}
```
</details>

## Investigate security risks

You can also use Copilot to investigate security risks, using Copilot chat ask the following question, review the output and look at suggestions 
```
@workspace are there any security risks?
```

Navigate to the **WebAppCustomers\Pages\Privacy.cshtml** or the **WebAppCustomers\Pages\Privacy.cshtml.cs** file depending on the Copilot output and implement the suggestion

Then, navigate to **WebAppCustomers\Program.cs** and fix the Cors based on the suggested code.

## Document the code

Navigate to the **WebAppCustomers\Data\TicketsRepository.cs** file and right click on each method and select the Copilot menu, Generate Docs, review the documentation and accept it

## Generate unit tests

Using Copilot Chat, ask to generate unit tests

```
@workspace /tests #file:TestHelper.cs Generate Unit tests
```

Accept the changes, save the file in the **TestProject1** project overwriting the **UnitTest1.cs** file
<details>
  <summary>Solution</summary>
  
```
public class UnitTest1
{
    [Fact]
    public void Factorial_WithZero_ReturnsOne()
    {
        // Arrange
        int input = 0;
        int expected = 1;

        // Act
        int result = TestHelper.Factorial(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Factorial_WithPositiveNumber_ReturnsFactorial()
    {
        // Arrange
        int input = 5;
        int expected = 120;

        // Act
        int result = TestHelper.Factorial(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Reverse_WithNonEmptyString_ReturnsReversedString()
    {
        // Arrange
        string input = "hello";
        string expected = "olleh";

        // Act
        string result = TestHelper.Reverse(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Reverse_WithEmptyString_ReturnsEmptyString()
    {
        // Arrange
        string input = "";
        string expected = "";

        // Act
        string result = TestHelper.Reverse(input);

        // Assert
        Assert.Equal(expected, result);
    }
}
```
</details>

Build the solution and using the test explorer menu execute the generated tests

![Test results](/Images/01_04.jpg)

## IaaC help

Navigate to the following file **IaaC\Resources.bicep**, use Copilot to generate a Bicep file to deploy a new app service and a new app service plan (Hint: // Generate app service and app service plan). We're not going to deploy the bicep file but you should see the required Bicep code 

<details>
  <summary>Solution</summary>
  
```


param location string = 'East US'
param sku string = 'F1'
param appName string = 'myappservice'
param planName string = 'myappserviceplan'

resource appServicePlan 'Microsoft.Web/serverfarms@2020-06-01' = {
  name: planName
  location: location
  sku: {
    name: sku
    tier: 'Free'
  }
  kind: 'linux'
  properties: {
    reserved: true
  }
}

resource appService 'Microsoft.Web/sites@2020-06-01' = {
  name: appName
  location: location
  properties: {
    serverFarmId: appServicePlan.id
    siteConfig: {
      appSettings: [
        {
          name: 'WEBSITE_RUN_FROM_PACKAGE'
          value: '1'
        }
      ]
    }
  }
}
```
</details>
