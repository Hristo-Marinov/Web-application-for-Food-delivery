﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodEx.Data.Migrations
{
    public partial class ImageFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "31ecb7c2-600a-419f-b8e1-d802c13f1fb5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "7e1015a5-2425-44dd-960b-2806d682933f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "4a4c127b-dbdf-4ed5-9f73-6963fcd5d188");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "014f6712-c702-4d66-9abd-86aafb845424");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59003e5a-1262-4964-9eac-3b0d6aeb4922", "AQAAAAEAACcQAAAAEELZCj8f/Rp4MVdfVZBsEX0l+XdiC3PH0g4qPMYKwXkk3aLeA4rkDle/Y9aZJuyY1w==", "02a73f35-905b-4f4c-88f1-9a32bb3cfbaf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deliveryguy-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6516f237-922f-402d-bf07-b8ea80dff6a4", "AQAAAAEAACcQAAAAEKfaFPutFLrULnRTqsSw8Yyyv0yAC+rNuNANtlHhg/Jmq1FRAy0yIGHz97hwzLkKNA==", "c9065509-7069-46fb-8d42-6bdff5071c21" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "regular-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c6165f4-c333-47f4-8fc3-391d34dbb3d3", "AQAAAAEAACcQAAAAEFdT7DKZ7abwAN9sfmUF++w0GV7M7tDOfjsX/UKw9O4pSTT2ZS5Rujp1Q1g8T6eGHg==", "d207288b-d57c-4cad-9f15-4416a92f5d70" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "restaurant-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4ef2d73-8d08-4801-9c49-8e2bf427837a", "AQAAAAEAACcQAAAAEMjNzfUGgkTDIpuJ/WfpMHxKbzsU3i9O6l9j4Mujz2A/wsuqXCNCBo+dj8moMDUlmA==", "e1fa2d99-c0ed-4365-827e-4fc71a056498" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 1,
                column: "ImageURL",
                value: "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBxQTEhUSEhMWFhUXGBoaFxgYGB8dGhgeHhcWGh0aIBoZHSggGh0lGx4YITEiJSkrLi4uHh8zODMsNygtLisBCgoKDg0OGxAQGy0mHyYwLS0wLS81LS0yLS0vLS0tLTAvLS0tLTUtLS0tLS0tLS0tLy0tLS0tLS0tLS0tLS0tLf/AABEIALcBEwMBIgACEQEDEQH/xAAcAAACAgMBAQAAAAAAAAAAAAAFBgMEAAIHAQj/xABGEAACAQIEAwUEBwUHAwMFAAABAhEDIQAEEjEFQVEGEyJhcTKBkaEHFCNCUrHBYoKy0fAVM2NykqLhJEPxg5PCJTREU6P/xAAaAQADAQEBAQAAAAAAAAAAAAABAgMEAAUG/8QAMREAAgICAgAEBAYCAQUAAAAAAAECEQMhEjEEE0FRImFx8DKBobHB0ZHxFAUjM0Lh/9oADAMBAAIRAxEAPwBp+i9IyMf4r/8Axw2xhR+jGoTkQSAD3j7THLqcNoOMxoPcZOPQcZGOOMx5GMjGTgnHmPcZj2McCzMZjMe446zMeExjGYASbAb45L257WNmT3NMOMpqh2Uw2YAMEIedOem/yxwQpx3tVVzrtluHtpoi1XNcj1Wn1/zc+VvFixwfhFPLpopjzYm7MerHmcQcAz+WdFSgQgW2giGB6Qdzz5nBtVx43ics5y4tUvY9DDCMVa2yvm6Oqm69VYfEHATsuZyWWP8Ag0x8FA/TDLpwu9mBGUpL+HUv+l2X9MZZr/tv6r9mWi/j/L+jOL8Kp10KVFkcjzXzBxzHjvZ+plWky1KfBUFiPI81b+hOw68cQZjLq6srAFSIYHYjoQcHw3jJ4XXa9v6OzeHjkXz9ziwr6gUdtBJtVFr9HjkfxC/WeRPIVXaadYFWWBq+607QxtJ+eLXHuEUKdYd3U1Uz7YEsyDybZunUc5wF4zULwyqNKgKi8kXkAvM8yx3x9FCanFNep5MouDphXNMoHd0x3pB3+6p9f5/DAzMZVjdjtyGw9Biz2c46IFGtA/C0QL8j5+eC2fyUXG2C9AWxa4dmO6fxC3I9D1x0PIVO9S7Qw5bR025G49Jwi53KTP8AXIY34JxZ6RC2nkT06Yjlx8laK4p8XTHyugZIQaWUhlb8LD8+h64u5fijN4tJnYjkp5+W+BNJyR3m4O88vPT+c/piQ5lQdwW5i222qPLb0jpjKt6NL1svcUyCV6LEorVEBKGCCNjAcQdwVtzcYU1yDPTFRaxNOYgqNYkSJbYgifujY+uGrK1qlTwqQo6wTHnptPIyDuMAXprSetltNmAJ1EEQSbBQAohg63BNje+NGFuqZDKldgmkyKStMF256bn0Zzt+8YxYyeeFMVKdQf3oAAQgldySWI08l21YslQBCgADYCwHoBYYA8VeHT/MPzxZ7JLQa4et/s00nk12f/Wbj0WB5YI8DybFnX9oyT/6JxLwVgtMELfqcb5KuZqdTUIt5rRMf7cZG27NKSVBGtlBKLqkl1t6HV+mH6mIGEXh6BaqM7AAMGJJ2id/WcOS8RpxOqfQHGbInpFV6l2MZgc3HKQMeL4D+eMwvFnEH0ZmcgjadOp6hiZ2crvA6YadeBfY7hbUMpTpMQSpfba9RyNwORGDJTyx61GAjD491Y9NIYjageWO2dolDY9xWgjG61OuCmCiWMZGPFON8NQDzEWczSUkapUYIiiWZjAA6k404jn6dCmatVtKjnzJNgABdmJsALk4ROM08xnCtUsKQRtVKgy6lEbNUAImpzEGE8zhZSUewxi2XM7WqcQ31U8nuE2fMeb80p/sbnnAsZOJ8LWpRNEDTbwED2GAsRGw5R0kYBniFWkZr0WX/FoEsD/mAE/6kYDrgtw7jq1BKslVfxKQG/PQfivpiPLdlOJzerlGVixLCoJU8iINxaxEjYyMF+A9raqutGqNU2DC/Im6kiDA3UxyCHBDtXRQ1BUQxrs6kFWDAWOk3ggb7W3vhNzSFTrG6sCPdik4RnHaFjJxejplXij1RpolUGzVDcqfwhSBpfycA/s4XOzWad0qPlmLU1qMpp14BLWJ0OosSTMEGSeWJcjxOgQCSWcqCpQnWAbxI+71DeHqMRcN4lVph1o0gZZzKae9UayDFtE9QsWiMZP+PGUarRo81xYbzGbdQNad0SJCvD1TttSpsbctTMoGBWZpPVuxOnoSC2/OIRP3QWH4zjMpnFZWK6SZ8Zk6wf8AEVhrDR+KfditmuIBTqY6uQIOw9MLj8Pjx9LY0ssp9vRLW4RTK+GL3PX5mfjfCxxLg5QyNvz/AK/rri9meLX1Bo9P164qLxcm0ahzB5/yxojkrsjKHsK/EuHz4lHSR7sWeC8fKAUq8lOTc18j5YuVKlatW7uhl2f8QW49Swsh9cQcR4E4gusBp0H8UGIkEgmZ233540c10yPF9ov1wt2kBQdzbkOuBGepBroDA5xA9ZO/ux5kMx3NQLVQFdgSJ0HynB/M0Q15kHY8oxz0d2UeCZ5qngeqygWIXwk8p1XPwjBOnlHpVqdSgo0ayCTuVA8Qk3OqCJ6CxvgDm8rofWtomY3jp77DymcM/BeK03RAxCgHckALCPbygx8sQyJx3EtCpaYy5CmNZ3K9P5/1Hriv20yIGiunLwsB0OkbDzCx6ucR0eIhSKlOWAs5AOkruGDGBvzmIJnBWjWzNaVmllzFwQXrBTaROkL5MNQ6E4hz8t83pFnHkuK7Oe5ji9NJBb3YXzUqZhyKVN2P7Klj8sdYyXYXKIdToardahn/AGiF+WGPK5NUGlFCgclAA+Awkv8AqMF+BX+h0fCSf4mJPDMhm9MCitMdazXH7iTPvIxbpdmGLQ1apUqVCSEpnukJsCxIl1UCATq6AAkgFrqgyERdTt7K7erE/dUWk+gEkgEzw7h4pAknU7Rrc2mNgPwqOQ9dySTnx5cuR30vl6/mVlGEVXbFHL9n6WWY00A1FQ9R+bMS2wJJAAFhJ8ySSSSWmsSfhirxjiaiqWVXqazpQpp0nSFEa3ZVnUWtMmDbGhbMtYJRpDkWZqh96qEA/wBRxbJNL8bFirXwotSv4fljMVv7MrG/1tx5LSpR7tSE/EnGYl5+P3/f+h+EvYfsvV0qBi3TcHaDigBjbh2SpGrV1gFhogzBug6Y9RSaaR57SpsIaRjzRjb6kPuVWHv1fxTjRstWGxR/WVP6jFt+xLXuYUxoaQxG2YdTDUn6+GGHyv8ALGDPpsWg9G8J+eO5INM27kY90YkDg42EYOgbEvN5SsavfZqkzFSe67sa6VMXAIVfGahXditpIECZ3pMjzoZWI3ANx6ruPfhyjFfN5ClVjvKavG2oAkeh3HuxOWK/UeOShXNCcB+I9nabsX06X/GhKt7ysEjyMjDhW4AP+1VdPJj3i/7/AB+4MMBeM5bMUwCzUlp2DVVI1SSFUBKpCKSTF2e8DSZtJ4pIosiYicZytekmlqq1UawV/DUJ3ldIhm9FXnfAAUWM94Yn7pEEeRItv0+OOopwyiDzFVrTVkVG5/fgkb2Hh6YWO0XC2ovrjwNuR90+fQEflhsbr4WCavYn8CyrVK60idKB1BVRACyAWjdoE3MnHR+1fC1yBpsvssriASYlkYHy+9hI4Zxelk89TqvTEC8ix36bfKfPHRO2PGRn8uiUaTaSw8bykSPuwrFrA7A4WdK7YY3qjnmdr9+wIW4sGEhh6EX9xtjT+zmWDUl1bbSR3g9E2f3QcNvBexKr4mrlxO1MaPcxu0/A4O1cjToUappIFOhr7sTpMSxufecZ3kS12W4HOsr2ZOavRCooN2Zr/wDtiW/1acMPD+wlCneqWrN+14U/0ruP8xODz8LUxaGUAKwswjz/AENsQVM3UpTq+0UbkAyvTVpB+NyeQxklnlPUdffv/ousajt7+/Y9zqijQYUlVDAWmFEAMxCrYcpIxonCVqIMtoDLpCqImIED3jC/x3tVTp1EFRwFXxiKbRr8S92b6tUEtOkAW32xd7NdtVqVVKALB2Y+I/8AHzx0cGRU2td2F5YbS7N+0X0YpQo95Y7ao5GPUzfnjnaK2XQjWCuqNLMqsgP3gSfEs8okdMdu47xxs1Teii6YAk7yxEhZ5Wg+8Y5BxrIwzUqsBuk3+HL12x60ZRb10YHFpb7NPqqmkdTA6oZWp7kdCSYIvMiI+OBOgUGDqogG5Pib1k8/SJxBlcw+WJV1LUp2NipPMc4+R3wXaiaighk0nbTLdeZj8sO0KmOXCa4rIHAm3ikz74wzcIq0npjL1SjaPYJImOUGZDKLSLxBxyPIzQqBX1Mh2GohfQgWI53GGPJ1lV0RRRCOCSLAzaFCi2kXPlv1xjlip0aVO0P+ayppgtTqq6j7lRgG9Fcb+jAk/iwuZ7tV3dZKJUAMCxdZZUF9zaDsIg7jrirn/taT0qZqOym6lDCwZszwZ5bkXtgG3DK501Fo+DSTqLEqLiSYB0xB3g4nHwmOW2NLPJaQ78N7U0gh7oFqkkO7CNiStjeApFrCSTzOKOZ4o9Uk1ah0cl2mwtA+7f1PpupjJsoJ+sIHZpZFUyggQw9oNN9yIgnciKGbGjUPacg6dbFiTaPCxEeirNrmN6rF6ITzPVnZeC0VagNSghgZBEgjkI6RjypwdVvRbR+ybp7hunuMDocch4oM9VzNYZenV0K5RSoIXwAJuYXlixlOx/E6l2bR/nrH8k1YnPFDqTQ0Zy9Ezq1LLVCJ7onzUqR0sSQT8BjMc+XsDnIvnSPRqhH8QxmI+T4b3+/8D+Zm9jr4GKKMe/rX2FPn+ycc/ofSa4PiSiR5VGB+D0gP92GHgHGHr6q5XQWtAgmFJUXBI2vjRlyJ19f4ZKGNq/p/KGxM25AI6XJEj5T8MAO0/HGXwoSABeJEkidjtaMb/WjMwCfWJ+WAXaJiWDfigEkg843HlGM3jck/KpOtq/oRywpWg12X47U1nvHGlUIEid2WNvf8cONLPI4uAR5/yax9xxzTgecQZgIZ8SMw9A6L1H4j8PLDEfas5HTz+EeWLeBz5PJXLYsMakrD+fo0Fpu+nRpUtKkjYE/dMYkTIWBp1ztPihv5H54Ue0NcjK1yDfuqnS/gN7EYK5LOMEQ+14R7rDqD13xtU490HhLqwzVo1lEgK/WDHXYEenPGgzhAl6dRf3ZHxWcDOI8XZKVVrQtNiL/skjY+XLFrhnGT3VInmib/AOUSeWG5ruxeD9i2udVrIyk9J/o4o8Spu6FaiJUUspggEWdSN+hAOPeJ8Vp6qK1KatrqaZgfgc/piTOHLImpnakJEnVYXEe1IF8NysHGi7p1rDqIO6nxD32jA3PcBpVFKDUgP4TYeisCo9wxPlAzrqSsjDUwhhBsxXcHy6Y31VQSppzAB8DA7zyMHkeWC2n2gbXTFPL9haWXbvKdJajfjIBf3A2X934YzP11XSGMMHUkHcSYuNxvzw0niKgw0of2gV/MYzOU6dZQGVagDowBEwVdWB9xE+7GXJ4aE3af8l45pRVNCrVzKKveDU3L7MFvdIsPeRhR4v2treIdw3d2uWuQCJBCAQSJAOqxixx1fNUaBMuAD1WQ3xW5HlgTnexlHNE6qlTTpMgQurbdlAOFx+EjD5hn4hy+QocA7Z5TMQhqtTc/9uqQs+QYWf0JnywZ4tWSEpgqAWBIkWC+If79Pzx7Q7K5PJjWcvTUqPaYajb9tpPzwI41lKRp99WSow0hNSFlNixKkgi0nY/DGXJijy+FNGiE3W2jzi/BhWp942Xaup8C92AWLaiIBkDfqY64RchwZqGbpitSrUj3i6ICvENsSkgsBe1vI7YfuGfSBl0y65VaVUusHUiioyz4g3hW7aSOWLL0Mu471yWmCdeoG8RNMxfaxXpi6rBHjtk3eV3pFCvRpXLVZVmJIepaefhJC+4rI2ttj2rkKBTTSViIsFpn5MQE+Jxrm83k6YiQKpvFEDWs8jHhAAizWMTGK3DeKVNRlvDe4XUy35jVHvAPoBjlLV0wtegC4hwlgCHp+D9srqXyhZB9CR5EXlfo5FqM92xKk2VV1DmDEzBA67npjqbLTYEVaxdTYgsAD5QgWfTBvs/lcjQosDRpqDsAAARHInn5z0w+LxHN8RMmHirOOmjSqpdi5NwS14jbQoteOn5RQyOYenUNFRbkAunpvJE+/DRQ4FTqV6vd5lqUkzSVb72YSd/QHz6YI8O7GZWm4Y1KtR51SziZBGwQA/njsniIR07v6HQxSe0e5EVqoACFGU6S2qCZUQQVuRBgiRdSb46TwzJUaWR7uq6jwvJsCNRJIAPqeW2AGX4TSZTqcaj901CwG2/iMmw29B1xcp8O0gd2rf5dDAe5gsfGfXCqc0rUbDKMXps5XxnK1XZ/q1DNsSwAb2KZUavxfekiDyExBvilwbsXnDUTXTWnTDqzqrCdIYTMEkzeAx9PLsVHLVahZe5ZNJjUzLewMi55Hcj3YIUuFNAUhQsyYYkn18IknrOGxzzP0SX6glHGvWwDW4zliR3y1KDke0VAIHKSpZSN7NPpjWvxumqFqbivGwpA6j6i4EDnP8sXsxwihROpTRTyYqP9xg/GfXHmSYZtqlGkVMLdtQZfEDsUJDRzuMZ545N1wKxnGr5FalxRiAe6qCeXdtbyxmGH+yFFmLk84Bj5csZgf8afsv8AJ3nRPnpeMUwJJgSVuD0mY3j3Y6T2RzRGWV1IEgm/mZxzWrwhnqCKNem14jSQTJMB1AUG8C4mANzfofYZlGVVG1IwBUI40vYxJXdZgH34fLGCpxf3sGPLdpjGmcWAbTN7x+YviLiNZGC6lDReAwPIxyA3j+hirnKrUUJILdPvGTy0kCfK5J6dUqhns3UYWIBYfdAAkgRMfl58sL3pksuRJ8Ug7UzbNWjLtTFXuyplFfSupSQhI1EiwJHhkgQbEFa9avADKQfxK7KfIwABhfoUAueVAQ0Zd91AmatOTCtvMnlzthwaixSEZV22n9LkYptUkwxxVtsV+1PEMwMsV0qR3JFVnYambTchQsA7mJ58ubNw+v8AZpFxpXmd4Ai03wk9pRnVoOlTS6hGLvdCYAvAWOpiTNhg1wHhGVUITTpo5CsRrBJaxFiYJm49cM18I0dPQX7ToPq9WbHu3tJv4D5dOWJeE1/sackiKaT1so/q2Kvad1GWqj2ZpsNJIH3TzDflibh7AUaZk/3abXPsi22El0US2UOL8QDtkqlK4erqpm4FT7OpPiIEfDDXwfPqY76nNohiHv6gAW2Fsc/7R1g1XJd0USoza1Vv+3qp1JDaDYgiCAd4uYwz5E1RS+2dC1thA9bn34dycKonwUyfhfEw6k0wAve1IFwYFV5Ejfn8ca5HizjPVV1GO5o6eX3q0772GAPZsj6oxaoaa6q8vOmPtal9UWgY34Qq1M9WLshHd0tMAaVg1BYCYneec45TdsLgqQ1r2jf64lMmVNGo3W4eiB+ZwQo8dpDMhBTUM1JmJAANnQe/fCe5H9oU5P8A+PU8/wDuUcQ1qpOfpKxCE0HCwR4z3inQAwM+ETtNjyGHjmloSWGI8UM1SerURXqIUCEzBHi1dRPLrjb6yxps61KbCWF5Q2YrzmbjCbkKmnNZoiTCUIi52q9ce9nuLLSyzPUTvUFWsNLfeBzLi4MxDE9bAbHZ45RJYh4qI7fZskagd4K7HmCenPFPiWap1KZovTDeKSDG4O9+eKD55tPhJB1yI3A0kfrgdmFkSdzgeffR3lV2XK3DfCTR0yASqMbSBYahcDzg4r8X7NZ2ondUXoqpHidkLNMzIRjp3g3n3YF9kqoWujONQg73+6euOipm0i2pdog2+Bt8sSwPFk+JqmPm8zH8K2cx7N9jDQZl7wVXJkqcuikST4iQNXI7nkemGStwyovhqPSppYyWE87EFgBEciflhpqaHvqBJgXEG08xbn0wucUqkr3fcvKkioUcBiPFpnTcKdx6jmYw0sMG+Ut/fyFjllVLRTy3A6FcllqJUKGWKBWKgBgGPiZSecEG3LeSmV4WkTTcMOo0gjyOhRf3jGmX4L3CqaAFLvI1wWkyCfECwnpPz5YVu1nFM1QrBKAov4R42JQi51DVr2gczjRGKSqqJOTb7G9OEUwdTDU/MlmM+Vzt5Y1zPCdJGZpJRimjyujxNq0mxG11XcGcJ3DO0maarS7+rTFMv4xTKHw6WJ5GBYXnDanbTIgMozKMANTaJaAObBQSvzw1JgtiXnu2fFCxXL5SnpE30M3kLmoqiwB9+L3Ce0+eFItnkZJdQrU1pwA1oKs5NiBJBtqFjycqtGlmFBy5RGkMWiNQkG53v5+eAWfy0PL0yWHSi7ki0xFNoU7YzzeS+Na90Wjw7LfaDMrl6au2YYl7kKZJOkbBeUDCyrjPo9EJEQ0uTqbewlI9wA8zhnAH1ZmCOjrdnakygCOlRVJHuwkZjiWVZorVlzBkEACybiQe8Cz1ABOJ8WpPXp83+46knHstZTsVlKahWooXY2Y6zJAkgDvNO17DDjk+HjIZcPl4JbdLR7rfrijS4PRbLmufDCzTBuYgGdLE85jC/wADzz5lqiCkPAAVhn56ogC4iP5YMPMW3bOlwekEq3aLMsxNhfmY2ttj3FheAV28SuQDtd/1bGY74vZnfD7nEclxCukOWqvoJV6Tk3K7wYgi0EbiefN84RxPvESvpYLP3oDLBKwxv4Sbe8YucY4Ll8pl3cUxXaBd28ToLbwAYU8heBMmJl4d2jVlNBKbBR4PvuRAmATKix3sfhaHiYQmlLi1Xsl+39mWLovcXcqi1kJVWTS2os6edlBANzYxeL88D+G8RoFqaKBpJk+N7SCpMTPXqbn1x6tJXBqNmVDFzCikbjUJJhxeRBJieWBtXQArUSQA12aJuGIIANhMgAdLzyVzUqp7+/8AB17u9lzMDVng1MIKapUQOKiliS9MhSCxaQFa3rgl3+mRqUsL3ZfPe1oj88LNGi9esKNN0ClWZiHAeVIBLAkF5kekcpGNuAyj1qTIXFJ6drr42pliGg3gqYkQIPPFuN+noXx5JJ8fQpdoc1XbLsa1FNRBJdIAiD4gSdREeV8FuE8Jy6BGGlHIViGYGWsQSNW87YFdpM/XqZdjUyzoQrTDeAeclrwLxHlgrwTh2VQI2lRUcKYdiZaxFtZEztisk+P9FV3+RY43nH+p1e8k1fGIU+AoZg+J7EDcX6DBXhdX/pqbEagKaTbaVEA4XuOnNihUFTu6gOqCPDpTSfMyZ/LzsR7PqKdBCqNL06Zbxe14ZBgt5nE8iXH+hoN3/YO7Q5nvKmTVSUqMwLQv90xpuNMkeIi4mPO1sNq12CKG8RVQJE3IG5gbnnhM7R5oO+TWp4ZYd8QyjS2ipOlg2oL5yLesYblaEVSrQEUJJB8P3YMyRE3O98Lk6X+/UaG2wZ2VzajJtrUuuuvK6C0/a1CRGx9MDOB1dWbqnJqlNTTpyHpkRerEICIM7yeUWO13su9UZRjSAL97mIDezPfVIkgyL4ocLrluIMaxFJxTTSqvPeT3wKwSNQA1ECLb74oluX3+hO+vv9Q7WqRxGnbfL1ef+JRvvgflM7TbPoKbd4q0nVixuh70Em4ljqgX5GxgYtV2/wDqVHb/AO3qyev2lDENelrz9JW1UyaNT2TpDfaJpXXPNbkEDbCL+B3/ACWqdX/qc54u7JTLw0AxPegWbedsCsvmR9SdSCGNaob21aczBMb2st/w+hwQy7Mc3mwsH7PLSGtaa88t4nC8KD/UmYHwitVDqfu/9SxDJaOczzmxERh4r+P2Ek/5/cfaLyxEDnz9MbVtX4TAUHVIi82jeRHzxXy40mxiAbsZ/DJJJwIr8eVVqBSXXcmSbDSo0i8jmY5weeExLTBmlTQS7N0x31PUYF/4Ww/ivSiJXaNo2t544Tl8+y8TWoCRSCsrCIBHcq5Y9W1aV25CYw3cS4q9NVqrEmU0OdMtqUaQ0mWuYgQb4nDlhVJJ3v8A+HZHHK7b60POezFCmtNSw1Oy01Mm7efhttvhL4fmmVq9QZqHNZ4XeyOQoMm9xOKNPilc1DrRCq6ytjqspNiTBPKRyxzzjVepTzNQkEK7O6Hkwm5Hv/q+Hxyc5dJCtKK7O/cVrlcmXnvD3cnUGKz3bNqg23Awn99QPcNUpbs8spJBCIXst1kg+7TiXOVn+o0lLKGqZcFVMgsO4M8/PpjmvE+0WYpaAtVwF1aVVhEmFJFjchiPjzxrwS5IjkjxH+hmMrWak1NAAYEwAYKNNgsH16ja+Od9ocmKWYKo1Rh3eo6i2kTlw1pUA77QINrxifstxVu9pK2rSFmnIBEaTzAmS0bztywCzOWzD1e9ejVLlNOosCPDS0CYQRYAcsVqntictH0LwmtX0BQAmhV3Tfzub7YvcI4s9dahYwyValPUFEkKY5yL74C8OeuPtFq0ClRUVF8QKwCD4ZEMWsQDeMQdmBXDV0WoDFarqkFZ8d2iOuKwpohJtDMuZZRWNRiyKQBKgiNCGwVRJknrgZxGhTDO1RDUSnTV+XhMvO5G4AtgHT7Q11zuYpVnpUqaESXqAa/AhkAi9hESDfnyX812yzNTN5jLFQqinp1K4I9sFXlVliZizbajyx3KO/kNxlodM3xl6qUnWnVSmX03sCoRrQrHnB92FvsbxKKjmmGUimlwD+Kr/Xxx5wzjdXuXp96ruiM58Qho38RAk9f3vXALsZne7qOlUMHcU1QRewruZEztMQDecQyb6K4012PzZ1pNnx5ilRzJYalSpB/w3HONis48xDizRaFLj+eNZw7MakMEAKxGttMFbgIQYm9t7m4TiWbNJahpIRrYy5FxcyBBt09BjcMzZlMwpNTLs7VAC20qRe8AhrdbYvcSpsWAcCrKklVuSRcraCGjmBFtsRmuNW7szb9AdwniwcBZKNqJO+g+yLbmev8AzjWlxdAxRkqRccgAdpMAn+j1wf4Zn8pRoahShjMJpgq23iJBYsIuPLC3xnigLmsqqveMC6wYWIkiDubNfzxNY05vRPYdytJKbLry8hqZPeG5U6x4dipBg3EbYzgdRadXNMAxFR6ZC7kMNQMlpksSTPrhXynEqteou7RZm1FQL2kmVXaAoF8N3ZzNxms1IBSsUeF/EslRA2JAL7bgnFljmlV1/stibtFXjuarPlKobLOh0sSNSkLY3JVQCIuR7sF+B8EpUqYqKiq1QKYcz4rRbaZuMVu2PenLEhHlqLmqq2FE6ASCzkaxJYSv4Z5xifg3AqKIjRqMKzB5YA2INwY8W2KuuPt9/U0rciHjeXzC0KmuoHnUST4YXSdgoufXy33wT7PZum9CnRR1asuXVyga4AVOhtcgRbfE3aJ0GXfXpTUjgSYklTAGqLz64DcD4zk0pUkNamj6EBkmNWkSJmN5wtWug3T7KfaUgVMkK4XSGVaupjFRtD6m0iwWYte5HvaMjVpsrLTXwpC9APCCIkXABG1htywC7TUO7fJk1GqaaqqVEOzHu6suZMajawAAwxtUXSIUiQCRNxK3UhTYg2tN8JkjpDY5bYC7NUNWUcK4SalcBgASPtnuMVcpUI4lV1U9ZanTuiQtP+8vcyAY87k9MXuzOg5WorrKGpmNQMtbvqkiIlrcufTGuWoMeIZjun0sadPWTcnx1R4TJGwjYiwwUtyA3qJLWqN/aNIwbUKv8dHrgfkZXOo1JmqhqFYKajyARVphhNzAa3/jGdrM2+XzdKoX0DuqihtLOSZpEgwDcwNhF+UYK9muBLmKa5x67io3eqCsU/Dq0g6TSMnwzDCLixthljdfkK8i/Uiy9cfWs4SJGjLWU3kGucD69dafD3R3QM1evALC8ZpyYmJj9Rthro9ouGUUFJ87TLKuhms7ki0lwlyL8okm2IsrlOH5spUp11rCjVdxqmzO2tlZRSgiYIFrKByxThS38ifmX18yHiiOUAVnGoxqpo7wCBeaSkKJgyeU+oGjsGe7WO8ptPjCknUJPM9QFsLDz3wzcU7bZfLVO4qJVEAFWSlqQqZAIi42IiOWK/ZHtRms4a+pFFNT9nCw1ySFN7nSCSeuDHGorROb5O2Vcv2Jo03FfQ61VltRdrmDMA+GbmwGKfEuzfeFnp1mRWTSViVkMhkRGm6yQPvX6zp2r7d1MjmDQakYZQ5YkqZMrJB3iJ9MIh47n8w2Yfv6s0vCqJYavFfQtjZW3m5Hlg8LO0hzp9lTrBNdnvLM0GopF10EggX3kXAHnJ/hHZzKd0yOoc0yGLMFLQBAYkrBJ8Qnyws9iMt9XoFCDrLlnPUlVvPO0fPGdqMpXFYPTy2aZjTCzTptpKln1KTHQnbrhUkpUNWrCXbTjOXULTUKe5QX0rqFwN1IC+CSbX8N+WE3ifa1a+hstk5ZYB1DVq8LSxVBvYGfL4meDdjPrKVKmYpVsu400wKiMxZTT0SJKmwtzwTzH0cqKQoUw13gVAAIEEknxSOa35wegw6kkBxsVezuTzVfOKxyqot20mV0gMFYHYqRJtAPMC2DXEOB1qT92dLWGruybFzA8bDrp+IMHD5wfglDL0RRpZdVAOqHUsdVvH4jdrC/kOgxeNFD7aAkxsNO2x3PkfdiWRKZygIAoDJ0tely1QMveUmnxAAhCA8SfEB4Tt6YN9k8i4U9+lRaryzsZRDJBiSpLGZMi1viQ4nkskz6a7w7QdJqqrHkDAAPlOAHHeDUaGYpmnlTUpuRLanY0yBF2uNLSN4Ag77YELh0F44y0EO0PZ1KrOzkvUIGkU01OFhd6jMAfIwsSLGJIp+y1OoaYLMrjWWWurIailQpUMjEQDcGTF7b417RE1EpFtSnRDadVmXwsvgBsDI+GAnCmOpS5Zh3qqitMRqYE6Ss+ySeV9OA5OTcvUdY4pKIHzFGkSFCsWICqF3uLExzkz6YienSmWU0xLnUpOsaRNl6Et022HXovBex1CszVgugqQVOpiC4FgRqiAOUEX2wV4z2Jy9UFjq1TJFPSpbwgWkchynzucFRkldk6ZyNqVPnmK3x+fv3xmHqp9HlAknVmR5RTMeUzjMdcvc7ixJ4bXpUw9J3Xu6ogganhzAV953iQPLphmy2RaqWcIawvd7QEWBJ3nf2eYHlC+3DKIIbUJDA+pALwAPQ32tjpnZGmBRC76e8X4VGB+YOBTnHlYZRSlQqUexZpq9OrV1FlXSVJBpnSSSViKkyJDGOdzilmezNEAgopKnUDrao7BYaDSGlQCJX2udr4euMGKzz+z/CuEzjWbprUZu7DOoAnazGHAPMwQINhPXE26fYJY4pWBez+Wpgg62RnGvWqeAhSbATYgi8WuPcR4lwHMNVqNlSWbSrgAqIM3ibLCyR/ma+GHI6dIiI/oYaeEZKlUpU2dipp1CRDRIlW0ldiJA+GH5Sb0Fw4xETh3YTNOGPEK2cVjGhKLl+s6zDJ0iD1nph37MdlBl6RBaC9metd2FoBiAYwxniVNZgnrYYF8Tza1CGDVRAIEEAX39+NEmhYpgvjn0dUc261KuYqeFdICBQI1E8w3XF7hPZShl2Ao0ghVQorFFLuOYYgCTN5IwoZnt3k8m7aajVKt1aJciNxqJC/ngHnvpjc/3dJvVnC/JF/XBVtdAffZ1lOz9FZd0Ws4OpSyLZoNwNpub73xUfjTo6omWTQY1sW7vSOcLpbVA6kTjk/CPpMqVKjfWaYNMLJKFpXxKJOpoIviTt52tQ5ZEylaGdvHplXCgbdQCY+BwGpXSQdVbOqZziXD6QOru0kkmIpySZJ3WSTgRwutkK2aaplqgZyiIwDKQqh3IaAp5tBMnlj5yZpMm588Pn0Q1iuZq7R3VwRc+IRB5dfhg5I1Fthg23SH36VchTGXUZZg9UMYFM7a1ZT7PICT6gYD5/iNTK5HK07ip3avJvBWg7sDffVHwbBjO1wasm+kQLbzGk/E1RgT2o1p3a1KbLK1CJttTMx0MHblIxm81t6RZY0ltnHycdA+ibNlDmNROgANHKeZ67RgZXzWTV100iRq8Z002tpbYqm+rTv54c+w3CRnO/7tjSp6QgMBjLAyIUgAiAfeMXnOUlVE4Qindm/azgrcVWj9X0o9L+8LyBpOrTcAkmQ9o5zgj2U7FtlqBpVK/iNTVqpT7OhxphxBOo79C3MDDjwns33Or7Utq0z4QAIL7X/a+WLzcPH4/l/wA4leSqSG+GxL7QdjGqUq1YVRUdVOlatAM7ALCqGUrpJPQECdjgNnuw1bu6iU1pbuCwYq0rEHTBnbVvMP5Y6S+XcuTqtsF+c48Th92YmdRDaStgQirI9yjFU0+ye10zj+X7V5inQ7mpTooUhFqsh1Np2MkQ8xucM3Zrt0tVUoZhmr12YzoVdPtWMAgiBEmJ3xP2n7B5fMOqjNGi/iZUOk6iZvFiQL2HnhKP0fcQoVdVMo8SA9NwDBBhgCwYQYkb9J3xzlYVGtHaVVEHeEvaNmkCTGxxrmeP0aZCvu3sqxWW8gCb4E1s+UytQVP7xF1EAETpXUSAT1Bt6Y519KfEyqUdNiSTMAwBEi9ovt5YTltKI3DVs6vmc5Qe7UifO388IPEe3vCgdIOY8J9qizqDvzVhqHrI2xUyHZ/ir5Pw1KSGqpBR2aQjJ5KdDidgYHPHOOOdkM5lATWoMEH318SepZZ0++MPBRb2xJWug7xrieRqs1Wlma/eMZIr0wdWwA1pEWgXB2wd7GZuoVrS5NN1CIAZAIUksOQPiA92Oa8Foh8xRVo0mogaRIjUJtztNsdP7G5U0zXys2o1SFnmjTBHUGDf/wAYGd8Y0hsC5StjKiFkJIgMdQ8tQBI/1aj78UatDQwbkAb9OZP5fDDFlqErcYq5+kqiIxgfubF7AvK9pVp5WtT1EEqxWojSVtFhyO5kc8UeOZ1nJ70V2TkFdzTj3G/vvij2lyid1UMANpMGB0xFw3hv1rNClRqKmmU8FQB1CkS2kMGCgmp/txXk5PSFUVFbZ7RymTYAjJ5s+a6ivuPd4zHS62ZWie6UwqAKL3gAb9T54zBdfdC8392cXqZSFYzJAa259nf0jVjpf0cOz5VHYHxmqdt5r1L4qv2Mo08wctRZ9VTLVSz1G1RJCI0LpAAYsYETthw4HkFy9KlSXTCLp8ItaCT6kksfM4p5i4qP5kVHdi92gH27/u/wLhYznB++LB1BsNJ6HVLSOYIt64b+Pj/qH/d/gXA4DEpbY/FNUylwzJ93TCkyRPzJMYaODAd0euo/kMBTip2hztWllVai5Ql21ERsFW1xa5G2DdBr0CfbWs1PJ1HV3QrpIKGG9tbT6cueFTK9uGWlNZS4YMtOoogh9BIDodrxcE9cMvapivDwpBdkWkWBN3I0gzzksQJ88cw4/limUVgrKe81BWUgjwwd7MLzqETzvi0JJ9/IlKLr/In1MRTiRabN7KlvQE/li1R4S5u0IP2jf4DGtyjHtkIxlLpHnCaGtmEX02sT95eSgk2nYY343lmpuqOulwgDL0ILD+WGDs9lO6MqWIDUzUaAIE6BA/8AU8+WGPO5Ra1ct3hUaU5eInxLM8vZ6HGaWepaNMcFrZzSjw+q2yN6kQPicO3YWh3FQTdmLAsslQNNlnrqGD+Y4VQSkxC6m8IljO7KNth8BiwhCqdOyZlNMbaWZVj3ScRyZ5TVFceGMXZayxIzFOqSYFRCRsIDT/PDd2v4OmZpaWbSQxIaJiVZTaRNmPPCvWBJMT8hhueuGoI7Oi6lElmAEgQbnzBxBNpMaaVpiXS7B5cb1nPoFH6Nhl4IlLJ0hTpglQ2osT4iSRcwoG0D0GPVdf8A99H/AN0fpirn6IZSBXoSRb7XCrJkTOcIsZM9RqgzTggmQChaOvskQMVqeWzBYGo0KOSrpHvJJPzwSynE6RBh1aCAdJBiZjb0OJ/raefwxuqL2ZbaPaTAicS6cQjNLFpj0x59cXzw1oWmU+KcGStc2awDADUIMjcHniCtwurYCo5HkY/UH4YKfXF6HGfX16HAaiG2CX7PKU0aORBJcmfUhg0+eFvjvZihVemK9IyrSviaNwT96GBAjDweIr0OI62epsIZCR54nLHe4umPHI130V6dQYkamDgPxji9HLJ3ripo1BbLqIJBI2vFt8A2+kvJryr3sPsyJPv3xNKXqh++hN7W9mUp5ypUy9E6dIMLARGIMkD0gwLXwf4Y/wD1VGpNq9Aqf8ykVF/2tU+GJmzK1mZyGhjOlhBHQEcjHLAzgpmlQv8AaUK+m55B3pn/APmx98Ym5OXf0LRgorR0ElQMU8ygi4nFmm0rirmRAEYQKFXtPC0neLgeEdWJhR72gYCcKo1MnVWpSJDqLyWKuTqDyJ572jB/jfjq0EI8Acu3mVHgX/UdX7uNq6qRt7txgqTS0GrFjPZ7MVKjVHaWY3hQB5WHQQMZgm+UrEzTWnp5Sb9Dy6zjMHm/cHBHW24bTFVsxfvGQUySTGkEtAHK5mcB+FZod5WpjdWVvjI5+gwfJkYW8nkGTOMxNnUiPPcfMYpkpOL/ACM8NplPjx+3f0X+BcUcXuP/AN+3ov8AAuKJOOfY66MxNxPJCpkDI/76oP3mpT+WICMGsvUnL0KY3OZLf6aZb8wMB9OzvVFLPUiaT+GC1SkFnyY1D8kwqdpsu5SlDKW7wr5DUhsTHRThz4oSz06Z3l6l+iro/OphZ49TAFMTJ+sU/wCCsP1GBYYiueHnZ3J8lsPif5DG1KgqHwoARsdz8TfBXMLEkQI3wLqVhveeuChm2wblqmmnVvcifcqIR/Di2tTx7/dH8T/zxWanYqAACCPiCMaU1kqZJkH/AOOOlL1OS9A4mZ1DSCZtzxfzjRQe2w1e9SG/MYFZY/hH8vjglRo6oDH1/liPNXspx0EnYmwPyxY4y4/syqjhWdXHdzcgvsfIzrxGtYCy/wDH/OAHE8zUesKaAMddM6SYX7MPUMmDHtLyxVCtDnwrsplhSQNRpsdIkkSSYvyxLmuzGV0sBQpAkGCBsY32xSocczcAGlQB8ncx/sGJcpxTMVa1OkWogMwDQjG0iYJcXieRwKvQjtbL3ZfhvccOQlQHcd61rmTInzCaRgoKtgRzwRziyrDkQR8owhZHtToOmpSnTIkG4g3sR+uLyVMivitjjTr6kVhdTI8wQSCCOoII92M7wYUOwfG2qVcyj3pPWJQn7rOWIU+RiPWBzwYz/Fe7zCZc0ahLtpDW0wQCGsdpkXi4PlKcnQzjToNFhiNnxI9dVsFB8ziNs4PwD4DHOaAokajU2mYtOIsyrJZvceRxIeIxcKPgMaNxhscsiRziylQYVkqUyJm49QbfPCH26yQOVZlUApDeYg3+U4fMzxYDVUq2Ci5AvuAB53xyztHSqV3qVaNR11sSaTNKQSbAGwMe70wqkrVsoovtIJcLzutFcn2lU+lr4ucGtVqiJBqI4/eUT81OFnss32WhvaRmUj5/qR7sNWQSI9QcSl8Mmiy2kxtp1IFtsZVq4rUqlsZUqwfXC2dRQ4rTkSLYDPVZTBWfMHBvNGcCcypI2k46xipmeMim2i9gPmAf1xmKB1SdVMkkkm4O5J3xmF8uPqNzZ3pnVbTfoMKPHuJMmay5FkNRQRAvJgSd+eDtGkx5fLA/ivBDUKsSF0kNMSZBnbb341zdxtmGFJlDj2WJzDx+z/CMRUeFseWHF6dAMXcyxAt7hivm+OIoimoHnjT5UFtsl5snpIpZTsvIlyAMQ1+GBKqGi4KrqmeRIAsB5fnipnuMuQSzQBuSdsBuD8fVqrqrhhbxA2NuRxOc8dUkPGM+2wxxDJBnFQkkhSvkQSCfPkMK/agALTMbV6Pp7YH64Z8znZFh8cLfHMs1VQqkFg6MJsPC6sfPlE4yOS5GiCYNzw1b/wDGKSZPVJkAfM4I5nKuQZI8o2/n+WKqUIG1+ZmfnjPPNrstHGB8xlmBsJ6HE1DLqoAMExsNh/Xni1VEb4qsJNhifNyRTgkTjMDYRi3kELHripTy0e0fdzwY4dYSYUfPDY2r0CXRdpUQN9+gws8AfVmqtU/dDGOutzp9+hF+OGCpnxBCbnmf0wA7PwEqP+OodPosIPyPxxsj0QYbr1i1gNK+X88QmsKMMG8QMrHIi4xBUrkDw/HFDMONtyfjhkhWzqFPj9JsoM0zBUCkv5MDpZfM6gQBztjkn9oh6rPUUoHYsBuLkmJHripVqOCtFmJpNqqaJtrsJ9YBxWq0ypEHw2ke/FXJepFQaehx+jLN03bM5RrFzqH7tjB5MCQR/wAYZOzPaRs5XNJ6IBy6ktV1bt7IAWLTc7/dxxrhXF/q1VMyPaRywvGq5BX0KyD646h9HNZWzOcZfZcU3Wd4JqRhZQ40Pd2OrriF1xYbEVTEWgFR0xCy4sviCpgUMKfaziDrUp0EYBXR2qAidQUppHl4rz5YCk3x72tzE59RyFML7z3jfouPMvuAdsJmW19C2Por8DXus5Wpnaoi1B+R+ZPww10UBM7YU+LPpzGWq8tRpseuoW+c4Y8q8sB78dPdS+X7aGjq0GUsZ/rljWuZIx5RHzx5VMRhLONKlQA7evwGK1YA3GLNZv1/h/5xAkbAen9HHBBzUvT+vdjMXTT9cZjrCdcAjEGaQkTMD4nGYzHozVxZ5cXsTu0PEEol6lRtKKFkwT90clGEfMdtHrNoyVHVJgPVMCfJAZPvIxmMxGP/AI+Ro/8AbiXct9H+azRDZ7MEjfQD4R+6vh+M4ceH9mqGVEokt1NzjzGYk25RthWnSLGcUEXEWi2+BGYPIYzGYw5W0asaBWcYAScCa2YnljMZiKVlyShkS4k2Bxu2Uj2RA688ZjMOuhSIgKb3P5Y9WTv/AOMZjMXgqQkivxOr3dN26KT8jirwujoRVPJRPrEk/GcZjMa4fhIy7J0JqSEsOZ5+7ErUgq236/8AnGYzBb2KkLvF0KvSYfiI+IOKdSqTM7DbGYzDraQr7F40mMMx5eAdB19cdR+jStpzBU7tl0P+kif4sZjMVzO2l9RMapM6TrxHUbHmMxmOKztijnM4qKXYwo3JmB7gCfljMZjkMcx7Q5gPmTWUkiUjlYNExysTi3RfeduWMxmFltJlloocZBNJoNwQy+qmfywx8JqavH1UHGYzHS/AdH8QVy1RhsZjYHF2o0wY/qDjMZiLKGjGbzG59MQVIsd7xO3XGYzHHHg9cZjMZjqOP//Z");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "7f5bf9c5-0d21-407a-9c30-2da31e5f30a7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "a5e314c2-582f-493c-8d7f-5e42fca6c75f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "c9d1b998-b534-48a1-baf2-df9899741278");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "1d0940d7-2352-48ff-9c03-e628a9888956");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe30a785-7617-46a8-8283-546997dd1682", "AQAAAAEAACcQAAAAEKm+wtuMlipHbItgQE8O8NL3A7DgGGg70Q06fXI94GFITO11nrTbBJFTDE7bCIoQGg==", "a34569ba-6363-403d-911b-282308a8626d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deliveryguy-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a085c339-2340-4958-8ef2-603fdf32521b", "AQAAAAEAACcQAAAAEJyJOMKOcjM0KzVHholI6sIrAOO2mU2RRsRbjfaOwySzLZFwl7rstka6IshcUiwfkg==", "49912922-c5e6-4aa2-aac8-c908522623ba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "regular-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43dfac11-7c89-4fdc-a451-ba805c2641df", "AQAAAAEAACcQAAAAED+3gg2HweWqDB00ZdrjM1vIeS5XwuT/8eWK+QAEna46ZobiNBQFnDdIoWo0VCtQbQ==", "70b9b22f-b6ee-4ae1-b622-1f9dd2a84e18" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "restaurant-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "516058a5-da36-43be-8821-1a4dc97ba5d2", "AQAAAAEAACcQAAAAEDV/gn6Yp1pGJjCM4SoL8rUy+pQWmdASampOwXtur7xeljWGxl3u9gUVd7uCIdxaBA==", "aea3fd58-88d6-45f0-b042-39afcc252a11" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 1,
                column: "ImageURL",
                value: "https://www.google.com/imgres?q=restaurant&imgurl=https%3A%2F%2Fariabgrestaurant.com%2Fuf%2Fgallery%2F2846172000%2Fl_dsc06678.jpg&imgrefurl=https%3A%2F%2Fariabgrestaurant.com%2F&docid=MtPFkaVDaWY6ZM&tbnid=unNF9LmsDUBKaM&vet=12ahUKEwjLyeuMvfiMAxW0QvEDHYdqE9kQM3oECGYQAA..i&w=1067&h=600&hcb=2&ved=2ahUKEwjLyeuMvfiMAxW0QvEDHYdqE9kQM3oECGYQAA");
        }
    }
}
