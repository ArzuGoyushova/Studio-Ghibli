import React , {useState, useEffect} from 'react'
import SearchResultsModal from '@/components/client/blog/SearchResultModal';
import BlogCard from '@/components/client/blog/BlogCard';
import BlogSidebar from '@/components/client/blog/BlogSideBar';
import axios from 'axios';

const Blog = () => {
    const [blogs, setBlogs] = useState([]);
    const [showSearchModal, setShowSearchModal] = useState(false);
    const [searchResults, setSearchResults] = useState([]);
    const [selectedCategoryId, setSelectedCategoryId] = useState(null);
    const [categoryBlogs, setCategoryBlogs] = useState([]);

  const handleCategoryClick = (categoryId) => {
    const categoryBlogs = blogs.filter(blog => blog.categoryId === categoryId && !blog.isDeleted);

    setSelectedCategoryId(categoryId);
    setCategoryBlogs(categoryBlogs);
  }; 
    useEffect(() => {
        fetchBlogs();
    }, []);

    const fetchBlogs = async () => {
        try {
            const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/Blog");
            const filteredBlogs = response.data.filter((e) => !e.isDeleted);
            setBlogs(filteredBlogs);
        } catch (error) {
            console.error("Error fetching blogs:", error);
        }
    };

    const handleGoBack = () => {
        setSelectedCategoryId(null);
        setCategoryBlogs([]);
      };

      const handleSearch = async (searchTerm) => {
        const filteredResults = blogs.filter(blog =>
          blog.title.toLowerCase().includes(searchTerm.toLowerCase())
        );
    
        setSearchResults(filteredResults);
        setShowSearchModal(true);
      };

  return (
      <div className="container mx-auto rounded-lg mt-5 mb-10 pb-5 md:pe-5 border flex flex-col md:flex-row">
      <div className="w-full md:w-1/4">
        <BlogSidebar blogs={blogs} onSearch={handleSearch} onCategoryClick={handleCategoryClick} />
      </div>
      <div className="w-full md:w-3/4">
      {selectedCategoryId !== null ? (
          <div>
            <button
              className="mt-2 mb-4 px-4 py-2 bg-gray-300 text-gray-700 rounded hover:bg-gray-400"
              onClick={handleGoBack}
            >
              Go Back
            </button>
            <div className="space-y-2">
              {categoryBlogs.map((blog, index) => (
              <BlogCard key={blog.id} blog={blog} /> 
            ))}
          </div>
          </div>
          ) : (
            <div>
      {blogs.map((blog) => (
                <BlogCard key={blog.id} blog={blog} /> 
            ))}
            </div>)}

            </div>
            {showSearchModal && (
        <SearchResultsModal
          searchResults={searchResults}
          onClose={() => setShowSearchModal(false)}
        />
      )}
    </div>
  )
}

export default Blog
