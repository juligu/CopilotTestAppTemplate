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

Locate the **Contructor** method, then use Copilot to generate 20 Tickets and Save them to the InMemory database
<details>
  <summary>Solution</summary>
  
  Add the following comment
```
  //Generate 20 Tickets data
```
Then copilot will suggest the required code, review it and double check that the SaveChanges() method is called after inserting the data
```
  public DataContext(DbContextOptions<DataContext> options) :
            base(options)
  {
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
    SaveChanges();
}
```
</details>

## Display generated data

Locate the following file **WebAppCustomers\Pages\Tickets\Index.cshtml.cs** and add a new public property, it should be a List<Tickets> object
<details>
  <summary>Solution</summary>
  
  ```
  public List<Ticket> Tickets { get; set; }
  ```
</details>


Then, add a contructor that receives the DataContext object as a parameter (Hint: you can ask copilot to add a constructor
<details>
  <summary>Solution</summary>
  
  ```
  public IndexModel(DataContext context)
  {
      Tickets = context.Tickets.ToList();
  }
  ```
</details>

Locate the following file **WebAppCustomers\Pages\Tickets\Index.cshtml**, you can create a comment to instruct Copilot to create a table to display the Tickets
```
@* Display a list of tickets *@
```
Complete copilot suggestions, it should look similar to this, double check the code and validate that it makes sense 

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




