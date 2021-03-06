using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.Domain;
using AlumniNetworkAPI.Models.DTO.Post;

using AutoMapper;
using AlumniNetworkAPI.Models.DTO.Replies;

namespace AlumniNetworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 
    public class PostsController : ControllerBase
    {
        private readonly AlumniNetworkDbContext _context;
        private readonly IMapper _mapper;

        public PostsController(AlumniNetworkDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostReadDTO>> GetPost(int id)
        {
            var post = await _context.Posts.Include(m => m.Replies).FirstOrDefaultAsync(m => m.Post_Id == id);



            if (post == null)
            {
                return NotFound();
            }

            var postToSend = _mapper.Map<PostReadDTO>(post);



            return postToSend;
        }

        // GET: api/Posts/group/5
        [HttpGet("group/{id}")]
        public async Task<ActionResult<PostReadDTO>> getPostByGroup(int id)
        {
            var post = await _context.Posts.Include(m => m.Replies).FirstOrDefaultAsync(m => m.TargetGroupId == id);



            if (post == null)
            {
                return NotFound();
            }

            var postToSend = _mapper.Map<PostReadDTO>(post);



            return postToSend;
        }

        // GET: api/Posts/topic/5
        [HttpGet("topic/{id}")]
        public async Task<ActionResult<PostReadDTO>> getPostByTopic(int id)
        {
            var post = await _context.Posts.Include(m => m.Replies).FirstOrDefaultAsync(m => m.TargetTopicId == id);



            if (post == null)
            {
                return NotFound();
            }

            var postToSend = _mapper.Map<PostReadDTO>(post);



            return postToSend;
        }



        // patch: api/Post/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch("{id}")]
        public async Task<IActionResult> PostUpdate(int id, PostUpdateDTO newPost)
        {
            var oldPost = await _context.Posts.AsNoTracking().Include(m => m.Replies).FirstOrDefaultAsync(m => m.Post_Id == id);

            var domainPost = _mapper.Map<Post>(newPost);

            domainPost.TimeStamp = oldPost.TimeStamp;
            domainPost.SenderUserId = oldPost.SenderUserId;
            domainPost.ReplyParentId = oldPost.ReplyParentId;
            domainPost.TargetUserId = oldPost.TargetUserId;
            domainPost.TargetGroupId = oldPost.TargetGroupId;
            domainPost.TargetTopicId = oldPost.TargetTopicId;


            if (id != domainPost.Post_Id)
            {
                return BadRequest();
            }
            _context.Entry(domainPost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PostReadDTO>> PostPost([FromBody] PostCreateDTO post)
        {
            var domainPost = _mapper.Map<Post>(post);

            domainPost.TimeStamp = DateTime.Now;

            _context.Posts.Add(domainPost);

            await _context.SaveChangesAsync();

            var PostToSend = _mapper.Map<PostReadDTO>(domainPost);

            return CreatedAtAction("getPost", new { id = domainPost.Post_Id }, PostToSend);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GEt: api/Replies/Posts/5

        [HttpGet("replies/{id}")]
        public ActionResult<IEnumerable<ReplyReadDTO>> GetAllMoviesFranchise(int id)
        {
            if (!PostExists(id))
            {
                return NotFound();
            }

            var ReplyList = _mapper.Map<List<ReplyReadDTO>>(_context.Replies.Include(p => p.Posts).Where(c => c.Post_Id == id).ToList<Reply>());

            return Ok(ReplyList);
        }


        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.Post_Id == id);
        }
    }
}
