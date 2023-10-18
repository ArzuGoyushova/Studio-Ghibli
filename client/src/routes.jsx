import {
  HomeIcon,
  UserCircleIcon,
  TableCellsIcon,
  BellIcon,
  UserPlusIcon,
  PaintBrushIcon,
  TagIcon,
  RectangleGroupIcon,
  FilmIcon,
  ShoppingBagIcon,
  BookOpenIcon
} from "@heroicons/react/24/solid";
import { Home, Category, Product, Movie, Colors, Sizes, About, Event, Blog, TicketOrder, Users, Roles, Subscriptions } from "@/pages/dashboard";


const icon = {
  className: "w-5 h-5 text-inherit",
};

export const routes = [
  {
    layout: "dashboard",
    pages: [
      {
        icon: <HomeIcon {...icon} />,
        name: "dashboard",
        path: "/home",
        element: <Home />,
        allowedRoles: ["Admin", "SuperAdmin", "SalesManager"]
      },
      {
        icon: <RectangleGroupIcon {...icon} />,
        name: "category",
        path: "/category",
        element: <Category />,
        allowedRoles: ["Admin", "SuperAdmin", "SalesManager"]
      },
      {
        icon: <ShoppingBagIcon {...icon} />,
        name: "ticketOrder",
        path: "/ticketOrder",
        element: <TicketOrder />,
        allowedRoles: ["Admin", "SuperAdmin", "SalesManager"]
      },
     
      {
        icon: <FilmIcon {...icon} />,
        name: "movie",
        path: "/movie",
        element: <Movie />,
        allowedRoles: ["Admin", "SuperAdmin", "SalesManager"]
      },
      {
        icon: <TableCellsIcon {...icon} />,
        name: "event",
        path: "/event",
        element: <Event />,
        allowedRoles: ["Admin", "SuperAdmin", "SalesManager"]
      },
      {
        icon: <BookOpenIcon {...icon} />,
        name: "blog",
        path: "/blog",
        element: <Blog />,
        allowedRoles: ["Admin", "SuperAdmin", "SalesManager"]
      },
      {
        icon: <BellIcon {...icon} />,
        name: "about",
        path: "/about",
        element: <About />,
        allowedRoles: ["Admin", "SuperAdmin", "SalesManager"]
      },
      {
        icon: <UserCircleIcon {...icon} />,
        name: "users",
        path: "/users",
        element: <Users />,
        allowedRoles: ["Admin", "SuperAdmin", "SalesManager"]
      },
      {
        icon: <UserPlusIcon {...icon} />,
        name: "roles",
        path: "/roles",
        element: <Roles />,
        allowedRoles: ["Admin", "SuperAdmin", "SalesManager"]
      },
      {
        icon: <TagIcon {...icon} />,
        name: "subscriptions",
        path: "/subscriptions",
        element: <Subscriptions />,
        allowedRoles: ["Admin", "SuperAdmin", "SalesManager"]
      },
      {
        icon: <ShoppingBagIcon {...icon} />,
        name: "product",
        path: "/product",
        element: <Product />,
        allowedRoles: ["Admin", "SuperAdmin", "SalesManager"]
      },
      {
        icon: <PaintBrushIcon {...icon} />,
        name: "colors",
        path: "/colors",
        element: <Colors />,
        allowedRoles: ["Admin", "SuperAdmin", "SalesManager"]
      },
      {
        icon: <TagIcon {...icon} />,
        name: "sizes",
        path: "/sizes",
        element: <Sizes />,
        allowedRoles: ["Admin", "SuperAdmin", "SalesManager"]
      },
    ],
  },
];

export default routes;
